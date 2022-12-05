using System;
using Shared;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Intrinsics.Arm;

namespace BusinessLayer.Interfaces
{
    public interface IBL_Campeonatos
    {
        List<Campeonato> GetCampeonatos();
        Campeonato GetCampeonato(int id);
        Campeonato AddCampeonato(Campeonato campeonato);
        Campeonato SetCampeonato(Campeonato campeonato);
        Campeonato SetPartidos(int idC , int idP);
        Campeonato DeletePartidos(int idC, int idP);
    }
}
