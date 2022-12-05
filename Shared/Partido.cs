using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class Partido
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public DateTime fecha { get; set; }
        public int golA { get; set; }
        public int golB { get; set; }
        public int idEquipoA { get; set; }
        public int idEquipoB { get; set; }
        public bool estado { get; set; }
        public int resultado { get; set; }
        public Partido(){}
    }
}
