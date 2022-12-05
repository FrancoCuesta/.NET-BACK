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
    public class EquiposController : ControllerBase
    {
        private IBL_Equipos _bl;
        private IDAL_Equipos _dal;

        public EquiposController()
        {
            _dal = new DAL_Equipos();
            _bl = new BL_Equipos(_dal);
        }

        // GET: api/<EquiposController>
        [HttpGet]
        public IEnumerable<Equipo> Get()
        {
            return _bl.GetEquipos();
        }

        // GET api/<EquiposController>/1
        [HttpGet("{id}")]
        public Equipo Get(int id)
        {
            return _bl.GetEquipo(id);
        }

        // POST api/<EquiposController>
        [HttpPost]
        public Equipo Post([FromBody] Equipo e)
        {
            return _bl.AddEquipo(e);
        }

        // PUT api/<EquiposController>
        [HttpPut]
        public Equipo Put([FromBody] Equipo e)
        {
            return _bl.SetEquipo(e);
        }



    }
}
