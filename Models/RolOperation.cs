using System;
using System.Collections.Generic;

#nullable disable

namespace MVCAPIAuthenticationTecsaUser.Moldels
{
    public partial class RolOperation
    {
        public int IdUp { get; set; }
        public int? IdRol { get; set; }
        public int? IdOperation { get; set; }

        public virtual Operation IdOperationNavigation { get; set; }
        public virtual Rol IdRolNavigation { get; set; }
    }
}
