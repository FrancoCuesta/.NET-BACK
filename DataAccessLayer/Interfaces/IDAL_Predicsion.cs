using System;
using Shared;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface IDAL_Predicsion
    {
        List<Predicsion> GetPredicsion();

        Predicsion Get(int id);

        Predicsion AddPredicsion(Predicsion e);
        
        Predicsion updatePredicsion(Predicsion e);

        Predicsion? existe(Predicsion e);

    }
}
