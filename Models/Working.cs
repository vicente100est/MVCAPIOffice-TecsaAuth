using System;
using System.Collections.Generic;

#nullable disable

namespace MVCAPIAuthenticationTecsaUser.Moldels
{
    public partial class Working
    {
        public Working()
        {
            WorkinTecsausers = new HashSet<WorkinTecsauser>();
        }

        public int IdWork { get; set; }
        public string TitleWork { get; set; }
        public string DescriptionWork { get; set; }
        public string StatusWork { get; set; }
        public int? IdRol { get; set; }

        public virtual Rol IdRolNavigation { get; set; }
        public virtual ICollection<WorkinTecsauser> WorkinTecsausers { get; set; }
    }
}
