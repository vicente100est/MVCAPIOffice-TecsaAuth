using System;
using System.Collections.Generic;

#nullable disable

namespace MVCAPIAuthenticationTecsaUser.Moldels
{
    public partial class WorkinTecsauser
    {
        public int IdWt { get; set; }
        public int? IdWork { get; set; }
        public int? IdUser { get; set; }
        public string HSTask { get; set; }
        public string DSTask { get; set; }
        public string HETask { get; set; }
        public string DETask { get; set; }

        public virtual Tecsauser IdUserNavigation { get; set; }
        public virtual Working IdWorkNavigation { get; set; }
    }
}
