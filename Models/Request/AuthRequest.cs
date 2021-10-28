using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCAPIAuthenticationTecsaUser.Models.Request
{
    public class AuthRequest
    {
        [Required]
        public string Email_user { get; set; }
        [Required]
        public string Password_user { get; set; }
    }
}
