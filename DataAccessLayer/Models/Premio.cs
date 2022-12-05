using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class Premio
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int id { get; set; }

        [MaxLength(128), MinLength(3), Required]

        public string descripcion { get; set; }

        [MinLength(1), Required ]

        public float monto { get; set; }
        public bool estado { get; set; }

        [ForeignKey("User"), Required]
        public string UserId { get; set; }
        public virtual Users User { get; set; }

        [ForeignKey("Penca"), Required]
        public int PencaId { get; set; }
        public virtual Penca Penca { get; set; }
        
        public Shared.Premio ToEntity()
        {
            return new Shared.Premio()
            {
                id = id,
                descripcion = descripcion,
                monto = monto,
                estado = estado,
                UserId = UserId,
                PencaId = PencaId
            };
        }

        public static Premio ToSave(Shared.Premio x)
        {
            return new Premio()
            {
                id = x.id,
                descripcion = x.descripcion,
                monto = x.monto,
                estado = x.estado,
                UserId = x.UserId,
                PencaId = x.PencaId
            };
        }

    }
}
