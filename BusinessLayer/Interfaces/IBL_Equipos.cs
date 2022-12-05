using System;
using Shared;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces
{
    public interface IBL_Equipos
    {
        List<Equipo> GetEquipos();
        Equipo GetEquipo(int id);
        Equipo AddEquipo(Equipo equipo);

        Equipo SetEquipo(Equipo equipo);
    }
}
