using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class Premio
    {
        public int id { get; set; }
        public string descripcion { get; set; }
        public Double monto { get; set; }
        public bool estado { get; set; }
        public string UserId { get; set; }
        public int PencaId { get; set; }
        public string cuenta { get; set; }

        public Premio()
        {

        }
    }
}
