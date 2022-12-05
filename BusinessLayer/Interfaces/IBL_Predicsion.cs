using System;
using Shared;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces
{
    public interface IBL_Predicsion
    {
        List<Predicsion> GetPredicsion();

        Predicsion Get(int id);

        Predicsion AddPredicsion(Predicsion e);

        Predicsion updatePredicsion(Predicsion e);

    }
}
