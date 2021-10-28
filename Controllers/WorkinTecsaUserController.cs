using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVCAPIAuthenticationTecsaUser.Models.Request;
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
    public class WorkinTecsaUserController : ControllerBase
    {
        [HttpPost]
        public IActionResult AddWTU(WorkinTecsaUserRequest oModel)
        {
            DateTime now = DateTime.Now;
            Answer oAnswer = new Answer();
            oAnswer.Successful = 0;
            try
            {
                using (tecsaofficeContext db = new tecsaofficeContext())
                {
                    WorkinTecsauser oWTU = new WorkinTecsauser();
                    oWTU.IdWork = oModel.Id_work;
                    oWTU.IdUser = oModel.Id_user;
//                    oWTU.HSTask = now.ToLongTimeString();
//                    oWTU.DSTask = now.ToString("yyyy/MM/dd");
                    oWTU.HETask = now.ToLongTimeString();
                    oWTU.DETask = now.ToString("yyyy/MM/dd");
                    db.WorkinTecsausers.Add(oWTU);
                    db.SaveChanges();
                    oAnswer.Successful = 1;
                }
            }
            catch (Exception ex)
            {
                oAnswer.Message = ex.Message;
            }

            return Ok(oAnswer);
        }

        [HttpDelete("{id}")]
        public IActionResult DelateWTU(int id)
        {
            Answer oAnswer = new Answer();
            oAnswer.Successful = 0;
            try
            {
                using (tecsaofficeContext db = new tecsaofficeContext())
                {
                    WorkinTecsauser oWTU = db.WorkinTecsausers.Find(id);
                    db.Remove(oWTU);
                    db.SaveChanges();
                    oAnswer.Successful = 1;
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
