using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCAPIAuthenticationTecsaUser.Models.Request
{
    public class WorkinTecsaUserRequest
    {
        public int Id_wt { get; set; }
        public int Id_work { get; set; }
        public int Id_user { get; set; }
        public string H_s_task { get; set; }
        public string D_s_task { get; set; }
        public string H_e_task { get; set; }
        public string D_e_task { get; set; }
    }
}
