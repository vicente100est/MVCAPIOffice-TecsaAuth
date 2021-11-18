using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVCAPIAuthenticationTecsaUser.Models.Response;
using MVCAPIAuthenticationTecsaUser.Moldels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCAPIAuthenticationTecsaUser.Controllers.GetMethods
{
    [Route("api/getmethods/[controller]")]
    [ApiController]
    public class RolOperationModuleController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetRolOperationModule()
        {
            Answer oAnswer = new Answer();
            oAnswer.Successful = 0;
            try
            {
                using (tecsaofficeContext db = new tecsaofficeContext())
                {
                    var rolOperationModule =
                        from ro in db.RolOperations
                        from rl in db.Rols
                        from op in db.Operations
                        from md in db.Modules
                        where ro.IdRol == rl.IdRol && ro.IdOperation == op.IdOperation && op.IdModule == md.IdModule
                        select new
                        {
                            ro.IdUp,
                            rl.Name,
                            op.NameOperation,
                            md.NameModule
                        };

                    oAnswer.Successful = 1;
                    oAnswer.Data = rolOperationModule.ToList();
                }
            }
            catch (Exception ex)
            {
                oAnswer.Message = ex.Message;
            }

            return Ok(oAnswer);
        }
    }
}
