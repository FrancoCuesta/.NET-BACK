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
    public class PremiosController : ControllerBase
    {
        private IBL_Premios _bl;
        private IDAL_Premios _dal;

        public PremiosController()
        {
            _dal = new DAL_Premios();
            _bl = new BL_Premios(_dal);
        }

        // GET: api/<PremiosController>
        [HttpGet]
        public IEnumerable<Premio> Get()
        {
            return _bl.GetPremios();
        }

        [HttpGet("getUsuario/{email}")]
        public IEnumerable<Premio> getUsuario(string email)
        {
            return _bl.getUsuario(email);
        }
        // GET api/<PremiosController>/1
        [HttpGet("{id}")]
        public Premio Get(int id)
        {
            return _bl.GetPremio(id);
        }

        // POST api/<PremiosController>
        [HttpPost]
        public Premio Post([FromBody] Premio p)
        {
            return _bl.AddPremio(p);
        }
        [HttpPut]
        public Premio Put(Premio p)
        {
            return _bl.SetPremio(p);
        }
        [HttpPut("cuenta")]
        public Premio cuenta(Premio p)
        {
            return _bl.cuenta(p);
        }

        // DELETE api/<PremiosController>/1
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _bl.DeletePremio(id);
        }


    }
}