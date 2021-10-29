using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCAPIAuthenticationTecsaUser.Models.Response;
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
            Answer oAnswer = new Answer();
            oAnswer.Successful = 0;
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

                    oAnswer.Successful = 1;
                    oAnswer.Data = operationModule;
                }
            }
            catch (Exception ex)
            {
                oAnswer.Message = ex.Message;
            }

            return Ok(oAnswer);
        }

        [HttpGet("{id}")]
        public IActionResult GetOpeationModuleSpecific (int id)
        {
            Answer oAnswer = new Answer();
            oAnswer.Successful = 0;
            try
            {
                using (tecsaofficeContext db = new tecsaofficeContext())
                {
                    var operationModule = db.Operations.Join(
                        db.Modules,
                        ope => ope.IdModule,
                        mod => mod.IdModule,
                        (ope, mod) =>
                            new { ope.IdOperation, ope.NameOperation, mod.NameModule }
                        ).FirstOrDefault(x => x.IdOperation == id);

                    oAnswer.Successful = 1;
                    oAnswer.Data = operationModule;
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
