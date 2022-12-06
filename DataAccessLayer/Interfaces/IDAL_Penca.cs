using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Models;
using Shared;

namespace DataAccessLayer.Interfaces
{
    public interface IDAL_Penca
    {
        List<Shared.Penca> GetPencasPublica();
        List<Shared.Penca> GetPencasPrivada(string id);
        Shared.Penca Get(int id);
        Shared.Penca AddPenca(Shared.Penca penca);
        Shared.Penca SetPenca(Shared.Penca penca);
        Shared.Penca AddCampeonato(int c , int p);
        Shared.Penca DeleteCampeonato(int p);
        Shared.User_Penca SetUsuarios(string u, int p);
        Shared.User_Penca Deleteusuarios(string u, int p);
        Shared.User_Penca EstasUnido(string u, int p);
        Shared.Penca finalizar(int penca);
        List<Users> GetUsuarios(int idP);
    }
}
