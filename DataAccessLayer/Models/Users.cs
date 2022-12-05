using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class Users : IdentityUser
    {
        [MaxLength(128), MinLength(3), Required]
        public string? Nombre { get; set; }
        [MaxLength(128), MinLength(3), Required]
        public string? Apellido { get; set; }
        public virtual ICollection<User_Penca> User_Penca { get; set; }
    }
}
