using System;
using System.Collections.Generic;

#nullable disable

namespace MVCAPIAuthenticationTecsaUser.Moldels
{
    public partial class Operation
    {
        public Operation()
        {
            RolOperations = new HashSet<RolOperation>();
        }

        public int IdOperation { get; set; }
        public string NameOperation { get; set; }
        public int? IdModule { get; set; }

        public virtual Module IdModuleNavigation { get; set; }
        public virtual ICollection<RolOperation> RolOperations { get; set; }
    }
}
