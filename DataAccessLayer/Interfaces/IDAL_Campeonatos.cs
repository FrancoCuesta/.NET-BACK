using System;
using Shared;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataAccessLayer.Interfaces
{
    public interface IDAL_Campeonatos
    {
        List<Campeonato> GetCampeonatos();

        Campeonato Get(int id);

        Campeonato AddCampeonato(Campeonato campeonato);

        Campeonato SetCampeonato(Campeonato campeonato);

        Campeonato SetPartidos(int idC, int idP);
        Campeonato DeletePartidos(int idC, int idP);
    }
}
