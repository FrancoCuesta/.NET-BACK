using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class Campeonato
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string? descripcion { get; set; }
        public DateTime fechaInicio { get; set; }
        public DateTime fechaFin { get; set; }
        public ICollection<Partido> partidos { get; set; }
        public Campeonato(){}
    }
}
