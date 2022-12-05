namespace WebAPI.Models
{
    public class UsuarioDTO
    {
        public string? Id { get; set; }

        public string? Nombre { get; set; }

        public string? Apellido { get; set; }

        public string? Email { get; set; }

        public string? Username { get; set; }

        public DateTime FechaHora { get; set; }

        public string[] Roles { get; set; } = { };
    }
}
