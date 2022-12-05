using System;
using Shared;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface IDAL_Equipos
    {
        List<Equipo> GetEquipos();

        Equipo Get(int id);

        Equipo AddEquipo(Equipo e);

        Equipo SetEquipo(Equipo e);



    }
}
