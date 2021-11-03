using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCAPIAuthenticationTecsaUser.Models.Response
{
    public class UserResponse
    {
        public int Id_user { get; set; }
        public string Email_user { get; set; }
        public string Token { get; set; }
    }
}
