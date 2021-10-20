using System;
using System.Collections.Generic;

#nullable disable

namespace MVCAPIAuthenticationTecsaUser.Moldels
{
    public partial class RollCall
    {
        public int IdDay { get; set; }
        public DateTime? NameDay { get; set; }
        public int? IdUser { get; set; }

        public virtual Tecsauser IdUserNavigation { get; set; }
    }
}
