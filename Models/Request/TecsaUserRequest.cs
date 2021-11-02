using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCAPIAuthenticationTecsaUser.Models.Request
{
    public class TecsaUserRequest
    {
        public int Id_user { get; set; }
        public string Name_user { get; set; }
        public string Email_user { get; set; }
        public string Password_user { get; set; }
        public string Date_user { get; set; }
        public int Id_rol { get; set; }
    }
}
