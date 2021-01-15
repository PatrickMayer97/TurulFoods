using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TurulFoods.Models
{
    public class LoginModel
    {
        
            [Required]
            public string Name { get; set; }
            [Required]
            [UIHint("password")]
            public string Password { get; set; }
        
    }
}
