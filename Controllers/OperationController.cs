using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVCAPIAuthenticationTecsaUser.Models.Response;
using MVCAPIAuthenticationTecsaUser.Models.Request;
using MVCAPIAuthenticationTecsaUser.Moldels;

namespace MVCAPIAuthenticationTecsaUser.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperationController : ControllerBase
    {
        [HttpPost]
        public IActionResult AddOperation(OperationRequest oModel)
        {
            Answer oAnswer = new Answer();
            oAnswer.Successful = 0;
            try
            {
                using (tecsaofficeContext db = new tecsaofficeContext())
                {
                    Operation oOperation = new Operation();
                    oOperation.NameOperation = oModel.Name_operation;
                    oOperation.IdModule = oModel.Id_module;
                    db.Operations.Add(oOperation);
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
        public IActionResult UpDateOperation(int id, OperationRequest oModel)
        {
            Answer oAnswer = new Answer();
            oAnswer.Successful = 0;
            try
            {
                using (tecsaofficeContext db = new tecsaofficeContext())
                {
                    Operation oOperation = db.Operations.Find(id);
                    oOperation.NameOperation = oModel.Name_operation;
                    oOperation.IdModule = oModel.Id_module;
                    db.Entry(oOperation).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
        public IActionResult DelateOperation(int id)
        {
            Answer oAnswer = new Answer();
            oAnswer.Successful = 0;
            try
            {
                using (tecsaofficeContext db = new tecsaofficeContext())
                {
                    Operation oOperation = db.Operations.Find(id);
                    db.Remove(oOperation);
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
