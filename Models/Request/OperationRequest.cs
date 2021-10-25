using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCAPIAuthenticationTecsaUser.Models.Request
{
    public class OperationRequest
    {
        public int Id_operation { get; set; }
        public string Name_operation { get; set; }
        public int Id_module { get; set; }
    }
}
