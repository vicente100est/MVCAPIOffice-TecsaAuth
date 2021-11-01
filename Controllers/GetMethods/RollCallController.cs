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
    public class RollCallController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetRollCall()
        {
            Answer oAnswer = new Answer();
            oAnswer.Successful = 0;
            try
            {
                using (tecsaofficeContext db = new tecsaofficeContext())
                {
                    var rollCall =
                        from rc in db.RollCalls
                        from tu in db.Tecsausers
                        from rl in db.Rols
                        where rc.IdUser == tu.IdUser && tu.IdRol == rl.IdRol
                        select new
                        {
                            rc.IdDay,
                            rc.NameDay,
                            tu.EmailUser,
                            rl.Name
                        };

                    oAnswer.Successful = 1;
                    oAnswer.Data = rollCall.ToList();
                }
            }
            catch (Exception ex)
            {
                oAnswer.Message = ex.Message;
            }

            return Ok(oAnswer);
        }

        [HttpGet("specific/{id}")]
        public IActionResult GetRollCallSpecific(int id)
        {
            Answer oAnswer = new Answer();
            oAnswer.Successful = 0;
            try
            {
                using (tecsaofficeContext db = new tecsaofficeContext())
                {
                    var rollCall =
                        from rc in db.RollCalls
                        from tu in db.Tecsausers
                        from rl in db.Rols
                        where rc.IdUser == tu.IdUser && tu.IdRol == rl.IdRol
                        select new
                        {
                            rc.IdDay,
                            rc.NameDay,
                            tu.EmailUser,
                            rl.Name
                        };

                    oAnswer.Successful = 1;
                    oAnswer.Data = rollCall.FirstOrDefault(x => x.IdDay == id);
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
