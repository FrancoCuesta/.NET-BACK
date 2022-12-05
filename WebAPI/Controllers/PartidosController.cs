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
    public class PartidosController : ControllerBase
    {
        private IBL_Partidos _bl;
        private IDAL_Partidos _dal;

        public PartidosController()
        {
            _dal = new DAL_Partidos();
            _bl = new BL_Partidos(_dal);
        }

        // GET: api/<PartidosController>
        [HttpGet]
        public IEnumerable<Partido> Get()
        {
            return _bl.GetPartidos();
        }

        // GET api/<PartidosController>/1
        [HttpGet("{id}")]
        public Partido Get(int id)
        {
            return _bl.GetPartido(id);
        }

        // POST api/<PartidosController>
        [HttpPost]
        public Partido Post([FromBody] Partido p)
        {
            return _bl.AddPartido(p);
        }

        // PUT api/<PartidosController>
        [HttpPut]
        public Partido Put([FromBody] Partido p)
        {
            return _bl.SetPartido(p);
        }
       
        [HttpPost]
        [Route("/CargarGoles")]
        public Partido CargarResultado(int id, int golA, int golB)
        {
            return _bl.CargarResultado(id, golA, golB);
        }
       
        
    }
}
