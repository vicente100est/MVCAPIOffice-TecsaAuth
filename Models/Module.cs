using System;
using System.Collections.Generic;

#nullable disable

namespace MVCAPIAuthenticationTecsaUser.Moldels
{
    public partial class Module
    {
        public Module()
        {
            Operations = new HashSet<Operation>();
        }

        public int IdModule { get; set; }
        public string NameModule { get; set; }

        public virtual ICollection<Operation> Operations { get; set; }
    }
}
