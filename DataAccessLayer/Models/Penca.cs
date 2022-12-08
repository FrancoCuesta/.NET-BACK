using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using DataAccessLayer.Migrations;

namespace DataAccessLayer.Models
{
    public class Penca
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public Double costo_entrada { get; set; }
        public Double poso { get; set; }
        public Double comision { get; set; }
        public int cant_participantes { get; set; }
        public int participantes { get; set; }
        public bool priada { get; set; }
        public int codigo { get; set; }
        public bool activa { get; set; }
        public virtual ICollection<User_Penca> User_Penca { get; set; }
       
        [ForeignKey("Campeonato")]
        public int? CampeonatoId { get; set; }

        public Shared.Penca ToEntity()
        {
            return new Shared.Penca()
            {
                Id = Id,
                Nombre = Nombre,
                costo_entrada = costo_entrada,
                poso = poso,
                comision = comision,
                cant_participantes = cant_participantes,
                priada = priada,
                codigo = codigo,
                CampeonatoId = CampeonatoId,
            };
        }

        public static Penca ToSave(Shared.Penca x)
        {
            return new Penca()
            {
                Id = x.Id,
                Nombre = x.Nombre,
                costo_entrada = x.costo_entrada,
                poso = x.poso,
                comision = x.comision,
                cant_participantes = x.cant_participantes,
                priada = x.priada,
                codigo = x.codigo,
                CampeonatoId = x.CampeonatoId,
                
            };
        }
    }
}
