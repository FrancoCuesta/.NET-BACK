using DataAccessLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.ObjectPool;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebAPI.Models;

namespace WebAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<Users> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;


        public AuthController(
                UserManager<Users> userManager,
                RoleManager<IdentityRole> roleManager,
                IConfiguration configuration)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
        }
        [HttpPost]
        [Route("Login")]
        [ProducesResponseType(typeof(LoginResponse), 200)]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            try
            {
                Users user = await _userManager.FindByNameAsync(model.Username);

                if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
                {
                    var userRoles = await _userManager.GetRolesAsync(user);

                    var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(ClaimTypes.NameIdentifier, user.Id),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

                    foreach (var userRole in userRoles)
                    {
                        authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                    }

                    var token = GetToken(authClaims);

                    return Ok(new LoginResponse
                    {
                        StatusOk = true,
                        StatusMessage = "Usuario logueado correctamente!",
                        IdUsuario = user.Id,
                        Token = new JwtSecurityTokenHandler().WriteToken(token),
                        Expiration = token.ValidTo,
                        Email = user.Email,
                        ExpirationMinutes = Convert.ToInt32((token.ValidTo - DateTime.UtcNow).TotalMinutes),
                        Nombre = user.Apellido + ", " + user.Nombre
                    });
                }
            }
            catch (Exception ex)
            {
                Unauthorized(new LoginResponse
                {
                    StatusOk = false,
                    StatusMessage = "Error: " + ex.Message,
                    Token = "",
                    Expiration = null
                });
            }

            return Unauthorized();
        }

        [HttpPost]
        [Route("Register")]
        [ProducesResponseType(typeof(StatusResponse), 200)]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            var userExists = await _userManager.FindByNameAsync(model.Email);
            if (userExists != null)
                return StatusCode(StatusCodes.Status500InternalServerError, new StatusResponse { StatusOk = false, StatusMessage = "El usuario ya existe!" });

            Users user = new()
            {
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.Email,
                Nombre = model.Nombre,
                Apellido = model.Apellido
            };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
            {
                string errors = "";
                result.Errors.ToList().ForEach(x => errors += x.Description + " | ");
                return StatusCode(StatusCodes.Status500InternalServerError, new StatusResponse { StatusOk = false, StatusMessage = "Error al crear usuario! Revisar los datos ingresados y probar nuevamente. Errores: " + errors });
            }

            // Asignar Rol User
           
            if(!await _roleManager.RoleExistsAsync("USER")){
                await _roleManager.CreateAsync(new IdentityRole("USER"));
            }
            await _userManager.AddToRoleAsync(user, "USER");

            // Envío notificación de activación.
            //_blNotificacion.EnviarVerificacionDeCorreo(user.Email, user.Nombre, user.Id);

            return Ok(new StatusResponse { StatusOk = true, StatusMessage = "Usuario creado correctamente!" });
        }

        [HttpGet]
        [Route("Usuario")]
        [Authorize(Roles = "USER")]
        public async Task<ActionResult<UsuarioDTO>> GetInformacionUsuario()
        {
            string username = User.FindFirstValue(ClaimTypes.NameIdentifier);
            Users usuario = await _userManager.Users.Where(x => x.UserName == username).FirstOrDefaultAsync();

            UsuarioDTO response = new UsuarioDTO()
            {
                Apellido = usuario.Apellido,
                Email = usuario.Email,
                Id = usuario.Id,
                Nombre = usuario.Nombre,
                Username = usuario.UserName
            };

            // TODO Agregar roles
            var userroles = await _userManager.GetRolesAsync(usuario);
            List<string> list = new List<string>();
            foreach (var role in userroles)
            {
                list.Add(role);
            }

            response.Roles = list.ToArray();

            return response;
        }

        [HttpGet]
        [Route("Usuarios")]
        [Authorize(Roles = "ADMIN")]
        public async Task<ActionResult<IEnumerable<UsuarioDTO>>> GetUsuarios()
        {
            return await _userManager.Users.Select(x => new UsuarioDTO()
            {
                Apellido = x.Apellido,
                Nombre = x.Nombre,
                Email = x.Email,
                Username = x.UserName,
            }).ToListAsync();
        }

        [HttpPost]
        [Authorize(Roles = "ADMIN")]
        [Route("AddRole")]
        [ProducesResponseType(typeof(StatusResponse), 200)]
        public async Task<IActionResult> AddRole([FromBody] AddRoleModel model)
        {
            var userExists = await _userManager.FindByNameAsync(model.UserName);
            if (userExists == null)
                return StatusCode(StatusCodes.Status500InternalServerError, new StatusResponse { StatusOk = false, StatusMessage = "No existe un usuario con username " + model.UserName });

            var roleExists = await _roleManager.FindByNameAsync(model.RoleName);
            if (roleExists == null)
                return StatusCode(StatusCodes.Status500InternalServerError, new StatusResponse { StatusOk = false, StatusMessage = "No existe un role con roleName " + model.RoleName });

            // Asignar Rol User
            await _userManager.AddToRoleAsync(userExists, roleExists.Name);

            return Ok(new StatusResponse { StatusOk = true, StatusMessage = "Rol agregado al usuario correctamente!" });
        }

        private JwtSecurityToken GetToken(List<Claim> authClaims)
        {
            string? JWT_SECRET = Environment.GetEnvironmentVariable("JWT_SECRET");
            if (string.IsNullOrEmpty(JWT_SECRET))
                JWT_SECRET = _configuration["JWT:Secret"];

            SymmetricSecurityKey? authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JWT_SECRET));

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddHours(3),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );

            return token;
        }

        [HttpGet]
        [Route("GetUsuario")]
        public async Task<ActionResult<UsuarioDTO>> GetUsuario(string username)
        {
            Users usuario = await _userManager.Users.Where(x => x.UserName == username).FirstOrDefaultAsync();
            if (usuario != null)
            {
                UsuarioDTO response = new UsuarioDTO()
                {
                    Apellido = usuario.Apellido,
                    Email = usuario.Email,
                    Id = usuario.Id,
                    Nombre = usuario.Nombre,
                    Username = usuario.UserName
                };
                var userroles = await _userManager.GetRolesAsync(usuario);
                List<string> list = new List<string>();
                foreach (var role in userroles)
                {
                    list.Add(role);
                }
                response.Roles = list.ToArray();

                return response;
            }
            else return null;
        }

    }
}
