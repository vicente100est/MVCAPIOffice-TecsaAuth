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
    public class WorkingController : ControllerBase
    {
        [HttpPost]
        public IActionResult AddTask(WorkingRequest oModel)
        {
            Answer oAnswer = new Answer();
            oAnswer.Successful = 0;
            try
            {
                using (tecsaofficeContext db = new tecsaofficeContext())
                {
                    Working oWorking = new Working();
                    oWorking.TitleWork = oModel.Title_Work;
                    oWorking.DescriptionWork = oModel.Description_work;
                    oWorking.StatusWork = oModel.Status_work;
                    oWorking.IdRol = oModel.Id_Rol;
                    db.Workings.Add(oWorking);
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
        public IActionResult UpDateTask(int id, WorkingRequest oModel)
        {
            Answer oAnswer = new Answer();
            oAnswer.Successful = 0;
            try
            {
                using (tecsaofficeContext db = new tecsaofficeContext())
                {
                    Working oWorking = db.Workings.Find(id);
                    oWorking.TitleWork = oModel.Title_Work;
                    oWorking.DescriptionWork = oModel.Description_work;
                    oWorking.StatusWork = oModel.Status_work;
                    oWorking.IdRol = oModel.Id_Rol;
                    db.Entry(oWorking).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
        public IActionResult DeleteTask(int id)
        {
            Answer oAnswer = new Answer();
            oAnswer.Successful = 0;
            try
            {
                using (tecsaofficeContext db = new tecsaofficeContext())
                {
                    Working oWorking = db.Workings.Find(id);
                    db.Remove(oWorking);
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
