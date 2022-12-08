using BusinessLayer.Interfaces;
using System;
using Shared;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Interfaces;

namespace BusinessLayer.Implementations
{
    public class BL_Premios : IBL_Premios
    {
        private IDAL_Premios _premios;

        public BL_Premios(IDAL_Premios premios)
        {
            _premios = premios;
        }

        public List<Premio>GetPremios()
        {
            return _premios.GetPremios();
        }

  
        public Premio AddPremio(Premio x)
        {
            return _premios.AddPremio(x);
        }

        public Premio SetPremio(Premio x)
        {
            return _premios.SetPremio(x);
        }

        public void DeletePremio(int id)
        {
            _premios.DeletePremio(id);
        }
        
       

        public Premio GetPremio(int id)
        {
            return _premios.GetPremio(id);
        }

        public IEnumerable<Premio> getUsuario(string email)
        {
            return _premios.getUsuario(email);
        }

        public Premio cuenta(Premio p)
        {
            return _premios.cuenta(p);
        }
    }
}
