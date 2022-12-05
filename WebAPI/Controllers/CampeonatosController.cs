using BusinessLayer.Implementations;
using BusinessLayer.Interfaces;
using DataAccessLayer.Implementations;
using DataAccessLayer.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared;


namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CampeonatosController : ControllerBase
    { 


        private IBL_Campeonatos _bl;
        private IDAL_Campeonatos _dal;

        public CampeonatosController()
        {
            _dal = new DAL_Campeonatos();
            _bl = new BL_Campeonatos(_dal);
        }

        // GET: api/<CampeonatosController>
        [HttpGet]
        public IEnumerable<Campeonato> Get()
        {
            return _bl.GetCampeonatos();
        }

        // GET api/<CampeonatosController>/1
        [HttpGet("{id}")]
         public Campeonato Get(int id)
         {
             return _bl.GetCampeonato(id);
         }

        // POST api/<CampeonatosController>
        [HttpPost]
        public Campeonato Post([FromBody] Campeonato c)
        {
            return _bl.AddCampeonato(c);
        }

        // PUT api/<CampeonatosController>
        [HttpPut]
        public Campeonato Put([FromBody] Campeonato c)
        {
            return _bl.SetCampeonato(c);
        }

        [HttpPut("SetPartido")]
        public Campeonato SetPartido(int idC, int idP) => _bl.SetPartidos(idC, idP);
        
        [HttpPut("DeletePartido")]
        public Campeonato DeletePartido(int idC, int idP) => _bl.DeletePartidos(idC, idP);

    }
}
