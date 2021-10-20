using System;
using System.Collections.Generic;

#nullable disable

namespace MVCAPIAuthenticationTecsaUser.Moldels
{
    public partial class Rol
    {
        public Rol()
        {
            RolOperations = new HashSet<RolOperation>();
            Tecsausers = new HashSet<Tecsauser>();
            Workings = new HashSet<Working>();
        }

        public int IdRol { get; set; }
        public string Name { get; set; }

        public virtual ICollection<RolOperation> RolOperations { get; set; }
        public virtual ICollection<Tecsauser> Tecsausers { get; set; }
        public virtual ICollection<Working> Workings { get; set; }
    }
}
