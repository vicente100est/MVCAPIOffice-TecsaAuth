using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCAPIAuthenticationTecsaUser.Models.Response
{
    public class Answer
    {
        public int Successful { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
    }
}
