using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCAPIAuthenticationTecsaUser.Moldels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCAPIAuthenticationTecsaUser.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetMethodsController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetOpeationModule()
        {
            try
            {
                using(tecsaofficeContext db = new tecsaofficeContext())
                {
                    var operationModule = db.Operations.Join(
                        db.Modules,
                        ope => ope.IdModule,
                        mod => mod.IdModule,
                        (ope,mod) =>
                            new { ope.IdOperation, ope.NameOperation, mod.NameModule }
                        ).ToList();

                    return Ok(operationModule);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
