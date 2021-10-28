using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCAPIAuthenticationTecsaUser.Models.Request
{
    public class WorkingRequest
    {
        public int Id_work { get; set; }
        public string Title_Work { get; set; }
        public string Description_work { get; set; }
        public string Status_work { get; set; }
        public int Id_Rol { get; set; }
    }
}
