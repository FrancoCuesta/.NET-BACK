using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class Predicsion
    {
        public int id { get; set; }
        public int golA { get; set; }
        public int golB { get; set; }
        public DateTime fecha { get; set; }
        public int Partidoid { get; set; }
        public int Pencaid { get; set; }
        public string UserId { get; set; }
    }
}
