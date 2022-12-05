using System;
using Shared;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface IDAL_Partidos
    {
        List<Partido> GetPartidos();
        Partido GetPartido(int id);
        Partido AddPartido(Partido p);
        Partido SetPartido(Partido p);

        Partido CargarResultado(int id, int golA, int golB);
        Partido Get(int id);
    }
}
