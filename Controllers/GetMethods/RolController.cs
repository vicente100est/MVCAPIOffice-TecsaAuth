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
    public class RolController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetRol()
        {
            Answer oAnswer = new Answer();
            oAnswer.Successful = 0;
            try
            {
                using (tecsaofficeContext db = new tecsaofficeContext())
                {
                    var lst = db.Rols.ToList();
                    oAnswer.Successful = 1;
                    oAnswer.Data = lst;
                }
            }
            catch (Exception ex)
            {
                oAnswer.Message = ex.Message;
            }

            return Ok(oAnswer);
        }

        [HttpGet("specific/{id}")]
        public IActionResult GetRolSpecific(int id)
        {
            Answer oAnswer = new Answer();
            oAnswer.Successful = 0;
            try
            {
                using (tecsaofficeContext db = new tecsaofficeContext())
                {
                    var lst = db.Rols.FirstOrDefault(x => x.IdRol == id);
                    oAnswer.Successful = 1;
                    oAnswer.Data = lst;
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
