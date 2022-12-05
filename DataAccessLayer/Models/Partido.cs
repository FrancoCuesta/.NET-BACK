using System;
using Shared;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics.CodeAnalysis;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Implementations;

namespace DataAccessLayer.Models
{
    public class Partido
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int id { get; set; }
        public string nombre { get; set; }
        public int golA { get; set; }
        public int golB { get; set; }
        public DateTime fecha { get; set; }
        public bool estado { get; set; }
        public int resultado { get; set; }
        [ForeignKey("Campeonatos"),AllowNull]
        public int? Campeonatoid { get; set; }
        
        [ForeignKey("Equipos"), Required]
        public int idEquipoA { get; set; }

        [ForeignKey("Equipos"), Required]
        public int idEquipoB { get; set; }
        public Shared.Partido ToEntity()
        {
            DAL_Equipos dal = new DAL_Equipos();
            return new Shared.Partido()
            {
                id = id,
                nombre = nombre,
                idEquipoA = idEquipoA,
                idEquipoB = idEquipoB,
                golA = golA,
                golB = golB,
                fecha = fecha,
                estado = estado,
                resultado = resultado

            };
        }

        public static Partido ToSave(Shared.Partido x)
        {
            DAL_Equipos dal = new DAL_Equipos();
            string ea = dal.Get(x.idEquipoA).nombre;
            string eb = dal.Get(x.idEquipoB).nombre;
            return new Partido()
            {
                id = x.id,
                nombre = ea +" vs " + eb,
                idEquipoA = x.idEquipoA,
                idEquipoB = x.idEquipoB,
                golA = x.golA,
                golB = x.golB,
                fecha = x.fecha,
                estado = x.estado,
                resultado = x.resultado
            };
        }
    }
}

