using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces
{
    public interface IBL_Penca
    {
        List<Penca> GetPencasPublica();
        List<Penca> GetPencasPrivada(string id);
        Penca Get(int id);
        Penca AddPenca(Penca penca);
        Penca SetPenca(Penca penca);
        Penca AddCampeonato(int c, int p);
        Penca DeleteCampeonato(int p);
        User_Penca SetUsuarios(string u, int p);
        User_Penca Deleteusuarios(string u, int p);
        User_Penca EstasUnido(string u, int p);
        Penca finalizar(int penca);
    }
}
