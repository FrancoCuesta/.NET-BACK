using System;
using Shared;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BusinessLayer.Interfaces
{
    public interface IBL_Premios
    {
        List<Premio> GetPremios();

        Premio GetPremio(int id);

        Premio AddPremio(Premio premio);

        void DeletePremio(int id);

        Premio SetPremio(Premio premio);
        IEnumerable<Premio> getUsuario(string email);
        Premio cuenta(Premio p);
    }
}
