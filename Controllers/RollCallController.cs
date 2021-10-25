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
    public class RollCallController : ControllerBase
    {
        [HttpPost]
        public IActionResult AddRollCall(RollCallRequest oModel)
        {
            Answer oAnswer = new Answer();
            oAnswer.Successful = 0;
            try
            {
                using (tecsaofficeContext db = new tecsaofficeContext())
                {
                    RollCall oRollCall = new RollCall();
                    oRollCall.NameDay = oModel.Name_day;
                    oRollCall.IdUser = oModel.Id_user;
                    db.RollCalls.Add(oRollCall);
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
        [HttpPut("{id}")]
        public IActionResult UpDateRollCall(int id, RollCallRequest oModel)
        {
            Answer oAnswer = new Answer();
            oAnswer.Successful = 0;
            try
            {
                using (tecsaofficeContext db = new tecsaofficeContext())
                {
                    RollCall oRollCall = db.RollCalls.Find(id);
                    oRollCall.NameDay = oModel.Name_day;
                    oRollCall.IdUser = oModel.Id_user;
                    db.Entry(oRollCall).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
        public IActionResult DeleteRollCall(int id)
        {
            Answer oAnswer = new Answer();
            oAnswer.Successful = 0;
            try
            {
                using (tecsaofficeContext db = new tecsaofficeContext())
                {
                    RollCall oRollCall = db.RollCalls.Find(id);
                    db.Remove(oRollCall);
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
