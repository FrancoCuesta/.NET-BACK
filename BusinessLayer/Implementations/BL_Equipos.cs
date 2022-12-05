using BusinessLayer.Interfaces;
using System;
using Shared;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Interfaces;

namespace BusinessLayer.Implementations
{
    public class BL_Equipos : IBL_Equipos
    {
        private IDAL_Equipos _equipos;

        public BL_Equipos(IDAL_Equipos equipos)
        {
            _equipos = equipos;
        }

        public List<Equipo> GetEquipos()
        {
            return _equipos.GetEquipos();
        }

        public Equipo GetEquipo(int id)
        {
            return _equipos.Get(id);
        }

        public Equipo AddEquipo(Equipo x)
        {
            return _equipos.AddEquipo(x);
        }

        public Equipo SetEquipo(Equipo equipo)
        {
            return _equipos.SetEquipo(equipo);
        }
    }
}
