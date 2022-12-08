using BusinessLayer.Interfaces;
using DataAccessLayer.Interfaces;
using Microsoft.EntityFrameworkCore.Update;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Implementations
{
    public class BL_Predicsion : IBL_Predicsion
    {
        private IDAL_Predicsion _Predicsion;
        public BL_Predicsion(IDAL_Predicsion Predicsion)
        {
            _Predicsion  = Predicsion;
        }
        public Predicsion AddPredicsion(Predicsion e)
        {
            if(_Predicsion.existe(e)!= null)
                throw new Exception("Ya existe la predicsion");
            
            return _Predicsion.AddPredicsion(e);
        }

        public Predicsion Get(int id)
        {
            return _Predicsion.Get(id);
        }

        public List<Predicsion> GetPredicsion()
        {
            return _Predicsion.GetPredicsion();
        }

        public Predicsion updatePredicsion(Predicsion e)
        {
            return _Predicsion.updatePredicsion(e);
        }

    }
}
