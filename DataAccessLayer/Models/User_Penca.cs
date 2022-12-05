using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    
    public class User_Penca
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        [ForeignKey("User"), Required]
        public string UserId { get; set; }
        public virtual Users User { get; set; }

        [ForeignKey("Penca"), Required]
        public int PencaId { get; set; }
        public virtual Penca Penca { get; set; }
        public Double puntaje { get; set; }

        public Shared.User_Penca ToEntity()
        {
            return new Shared.User_Penca()
            {
                Id = Id,
                UserId = UserId,
                PencaId = PencaId,
                puntaje = puntaje,
            };
        }

        public static User_Penca ToSave(Shared.User_Penca x)
        {
            return new User_Penca()
            {
                Id = x.Id,
                UserId = x.UserId,
                PencaId = x.PencaId,
                puntaje = x.puntaje,
            };
        }
    }
}
