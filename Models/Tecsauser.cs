using System;
using System.Collections.Generic;

#nullable disable

namespace MVCAPIAuthenticationTecsaUser.Moldels
{
    public partial class Tecsauser
    {
        public Tecsauser()
        {
            RollCalls = new HashSet<RollCall>();
            WorkinTecsausers = new HashSet<WorkinTecsauser>();
        }

        public int IdUser { get; set; }
        public string NameUser { get; set; }
        public string EmailUser { get; set; }
        public string PasswordUser { get; set; }
        public DateTime? DateUser { get; set; }
        public int? IdRol { get; set; }

        public virtual Rol IdRolNavigation { get; set; }
        public virtual ICollection<RollCall> RollCalls { get; set; }
        public virtual ICollection<WorkinTecsauser> WorkinTecsausers { get; set; }
    }
}
