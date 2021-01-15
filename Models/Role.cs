﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TurulFoods.Models
{
    [Table("Role")]
    public class Role
    {
        [Key, Required]
        public int RoleId { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
