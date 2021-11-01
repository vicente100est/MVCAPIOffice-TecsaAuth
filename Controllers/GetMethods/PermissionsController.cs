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
    [Route("api/getmethod/[controller]")]
    [ApiController]
    public class PermissionsController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetPermissions()
        {
            Answer oAnswer = new Answer();
            oAnswer.Successful = 0;
            try
            {
                using (tecsaofficeContext db = new tecsaofficeContext())
                {
                    var permissionModule =
                        from ro in db.RolOperations
                        from r in db.Rols
                        from o in db.Operations
                        from m in db.Modules
                        where ro.IdRol == r.IdRol && ro.IdOperation == o.IdOperation && o.IdModule == m.IdModule
                        select new
                        {
                            ro.IdUp,
                            r.Name,
                            o.NameOperation,
                            m.NameModule
                        };

                    oAnswer.Successful = 1;
                    oAnswer.Data = permissionModule.ToList();
                }
            }
            catch (Exception ex)
            {
                oAnswer.Message = ex.Message;
            }

            return Ok(oAnswer);
        }

        [HttpGet("specific/{id}")]
        public IActionResult GetPermissionsSpecific(int id)
        {
            Answer oAnswer = new Answer();
            oAnswer.Successful = 0;
            try
            {
                using (tecsaofficeContext db = new tecsaofficeContext())
                {
                    var permissionModule =
                        from ro in db.RolOperations
                        from r in db.Rols
                        from o in db.Operations
                        from m in db.Modules
                        where ro.IdRol == r.IdRol && ro.IdOperation == o.IdOperation && o.IdModule == m.IdModule
                        select new
                        {
                            ro.IdUp,
                            r.Name,
                            o.NameOperation,
                            m.NameModule
                        };

                    oAnswer.Successful = 1;
                    oAnswer.Data = permissionModule.FirstOrDefault(x => x.IdUp == id);
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
