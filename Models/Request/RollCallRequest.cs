using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCAPIAuthenticationTecsaUser.Models.Request
{
    public class RollCallRequest
    {
        public int Id_Day { get; set; }
        public DateTime Name_day { get; set; }
        public int Id_user { get; set; }
    }
}
