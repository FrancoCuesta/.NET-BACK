using System;
using Shared;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using DataAccessLayer.Migrations;

namespace DataAccessLayer.Models
{
    public class Campeonato
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int id { get; set; }
        
        [MaxLength(128), MinLength(3), Required]
        public string nombre { get; set; }

        [Required]
        public DateTime fechaInicio { get; set; }

        [Required]
        public DateTime fechaFin { get; set; }

        [MaxLength(256), MinLength(3), Required]
        public string? descripcion { get; set; }

        
        public ICollection<Partido>? partidos { get; set; }

        public Shared.Campeonato ToEntity()
        {
            return new Shared.Campeonato()
            {
                id = id,
                nombre = nombre,
                descripcion = descripcion,
                fechaInicio = fechaInicio,
                fechaFin = fechaFin,
                partidos = (ICollection<Shared.Partido>)partidos,
            };
        }

        public static Campeonato ToSave(Shared.Campeonato x)
        {
            return new Campeonato()
            {
                id = x.id,
                nombre = x.nombre,
                descripcion = x.descripcion,
                fechaInicio = x.fechaInicio,
                fechaFin = x.fechaFin,
            };
        }

    }
}
