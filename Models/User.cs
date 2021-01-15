using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TurulFoods.Models
{
    [Table("tblUser")]
    public class User
    {
        [Key, Required]
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
        public string Email { get; set; }
        public string City { get; set; }

        
        
        public virtual ICollection<UserRole> UserRoles { get; set; }

    }
}
