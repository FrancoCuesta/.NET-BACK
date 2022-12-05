using System;
using Shared;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces
{
    public interface IBL_Partidos
    {
        List<Partido> GetPartidos();
        Partido GetPartido(int id);
        Partido AddPartido(Partido partido);
        Partido SetPartido(Partido partido);
        Partido CargarResultado(int id, int golA, int golB);
    }
}
