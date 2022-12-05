using System;
using Shared;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface IDAL_Premios
    {
        List<Premio> GetPremios();

        Premio GetPremio(int id);

        Premio AddPremio(Premio premio);

        Premio SetPremio(Premio premio);
        void DeletePremio(int id);
        Premio Get(int id);
    }
}
