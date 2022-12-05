using BusinessLayer.Implementations;
using BusinessLayer.Interfaces;
using DataAccessLayer.Implementations;
using DataAccessLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Shared;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PencaController : ControllerBase
    {
        private IBL_Penca _bl;
        private IDAL_Penca _dal;

        public PencaController()
        {
            _dal = new DAL_Penca();
            _bl = new BL_Penca(_dal);
        }

        [HttpGet("GetMisPencas/{Email}")]
        public IEnumerable<Penca> GetPencasPrivada(string Email) => _bl.GetPencasPrivada(Email);

        [HttpGet("GetPencasPublica")]
        public IEnumerable<Penca> GetPencasPublica() => _bl.GetPencasPublica();

        [HttpGet("{id}")]
        public Penca Get(int id) => _bl.Get(id);

        [HttpPost]
        public Penca Post([FromBody] Penca p) => _bl.AddPenca(p);

        [HttpPut]
        public Penca Put([FromBody] Penca p) => _bl.SetPenca(p);

        [HttpPut("SetCampeonato")]
        public Penca SetCampeonato(int idC, int idP) => _bl.AddCampeonato(idC, idP);

        [HttpPut("DeleteCampeonato")]
        public Penca DeleteCampeonato(int idC, int idP) => _bl.DeleteCampeonato(idP);

        [HttpPut("SetUsuario")]
        public User_Penca SetUsuario(string idU, int idP) => _bl.SetUsuarios(idU, idP);

        [HttpPut("DeleteUsuario")]
        public User_Penca DeleteUsuario(string idU, int idP) => _bl.Deleteusuarios(idU, idP);

        [HttpPut("EstasUnido")]
        public User_Penca EstasUnido(string idU,int idP) => _bl.EstasUnido(idU, idP);

        [HttpPut("Finalizar")]
        public Penca Finalizar(int idP) => _bl.finalizar(idP);
    }
}
