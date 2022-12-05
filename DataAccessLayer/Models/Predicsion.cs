using DataAccessLayer.Implementations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class Predicsion
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int id { get; set; }
        public int golA { get; set; }
        public int golB { get; set; }
        public DateTime fecha { get; set; }

        [ForeignKey("Partido"), Required]
        public int Partidoid { get; set; }
        public Partido Partido { get; set; }

        [ForeignKey("Penca"), Required]
        public int Pencaid { get; set; }
        public Penca Penca { get; set; }

        [ForeignKey("User"), Required]
        public string UserId { get; set; }
        public virtual Users User { get; set; }

        public Shared.Predicsion ToEntity()
        {
            return new Shared.Predicsion()
            {
                id = id,
                golA = golA,
                golB = golB,
                fecha = fecha,
                Partidoid = Partidoid,
                Pencaid = Pencaid,
                UserId = UserId
            };
        }
        public static Predicsion ToSave(Shared.Predicsion x)
        {
            return new Predicsion()
            {
                id = x.id,
                golA = x.golA,
                golB = x.golB,
                fecha = x.fecha,
                Partidoid = x.Partidoid,
                Pencaid = x.Pencaid,
                UserId = x.UserId
            };
        }
    }
}
