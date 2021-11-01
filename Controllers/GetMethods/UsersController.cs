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
    public class UsersController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetUsers()
        {
            Answer oAnswer = new Answer();
            oAnswer.Successful = 0;
            try
            {
                using (tecsaofficeContext db = new tecsaofficeContext())
                {
                    var user = (
                        from tu in db.Tecsausers
                        from rl in db.Rols
                        where tu.IdRol == rl.IdRol
                        select new
                        {
                            tu.IdUser,
                            tu.NameUser,
                            tu.EmailUser,
                            tu.DateUser,
                            rl.Name
                        }).ToList();

                    oAnswer.Successful = 1;
                    oAnswer.Data = user;
                }
            }
            catch (Exception ex)
            {
                oAnswer.Message = ex.Message;
            }

            return Ok(oAnswer);
        }

        [HttpGet("specific/{id}")]
        public IActionResult GetUsersSpecific(int id)
        {
            Answer oAnswer = new Answer();
            oAnswer.Successful = 0;
            try
            {
                using (tecsaofficeContext db = new tecsaofficeContext())
                {
                    var user = (
                        from tu in db.Tecsausers
                        from rl in db.Rols
                        where tu.IdRol == rl.IdRol
                        select new
                        {
                            tu.IdUser,
                            tu.NameUser,
                            tu.EmailUser,
                            tu.DateUser,
                            rl.Name
                        }).FirstOrDefault(x => x.IdUser == id);

                    oAnswer.Successful = 1;
                    oAnswer.Data = user;
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
