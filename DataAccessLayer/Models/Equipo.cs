using System;
using Shared;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class Equipo{

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int id { get; set; }

        [MaxLength(128), MinLength(3)]
        public string nombre { get; set; }

        [MinLength(2)]
        public string imagen { get; set; }

        public Shared.Equipo ToEntity()
        {
            return new Shared.Equipo()
            {
                id = id,
                nombre = nombre,
                imagen = imagen
            };
        }

        public static Equipo ToSave(Shared.Equipo x)
        {
            return new Equipo()
            {
                id = x.id,
                nombre = x.nombre,
                imagen = x.imagen
            };
        }
    }
}

