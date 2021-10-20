using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVCAPIAuthenticationTecsaUser.Moldels;
using MVCAPIAuthenticationTecsaUser.Models.Response;

namespace MVCAPIAuthenticationTecsaUser.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModuleController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetModules()
        {
            Answer oAnswer = new Answer();
            oAnswer.Successful = 0;
            using (tecsaofficeContext db = new tecsaofficeContext())
            {
                try
                {
                    var lst = db.Modules.ToList();
                    oAnswer.Successful = 1;
                    oAnswer.Data = lst;
                }
                catch (Exception ex)
                {
                    oAnswer.Message = ex.Message;
                }

                return Ok(oAnswer);
            }
        }
    }
}
