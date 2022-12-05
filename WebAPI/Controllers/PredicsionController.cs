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
    public class PredicsionController : ControllerBase
    {
        private IBL_Predicsion _bl;
        private IDAL_Predicsion _dal;

        public PredicsionController()
        {
            _dal = new DAL_Predicsion();
            _bl = new BL_Predicsion(_dal);
        }

        // GET: api/<PredicsionController>
        [HttpGet]
        public IEnumerable<Predicsion> Get()
        {
            return _bl.GetPredicsion();
        }

        // GET api/<PredicsionController>/1
        [HttpGet("{id}")]
        public Predicsion Get(int id)
        {
            return _bl.Get(id);
        }

        // POST api/<PredicsionController>
        [HttpPost]
        public Predicsion Post([FromBody] Predicsion e)
        {
            return _bl.AddPredicsion(e);
        }

        // PUT api/<PredicsionController>
        [HttpPut]
        public Predicsion Put([FromBody] Predicsion e)
        {
            return _bl.updatePredicsion(e);
        }
    }
}
