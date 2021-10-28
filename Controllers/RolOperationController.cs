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
    public class RolOperationController : ControllerBase
    {
        [HttpPost]
        public IActionResult AddRolOperation(RolOperationRequest oModel)
        {
            Answer oAnswer = new Answer();
            oAnswer.Successful = 0;
            try
            {
                using (tecsaofficeContext db = new tecsaofficeContext())
                {
                    RolOperation oRO = new RolOperation();
                    oRO.IdRol = oModel.Id_rol;
                    oRO.IdOperation = oModel.Id_operation;
                    db.RolOperations.Add(oRO);
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
        public IActionResult UpDateRolOperation(int id, RolOperationRequest oModel)
        {
            Answer oAnswer = new Answer();
            oAnswer.Successful = 0;
            try
            {
                using (tecsaofficeContext db = new tecsaofficeContext())
                {
                    RolOperation oRO = db.RolOperations.Find(id);
                    oRO.IdRol = oModel.Id_rol;
                    oRO.IdOperation = oModel.Id_operation;
                    db.Entry(oRO).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
        public IActionResult DelateRolOperation(int id)
        {
            Answer oAnswer = new Answer();
            oAnswer.Successful = 0;
            try
            {
                using (tecsaofficeContext db = new tecsaofficeContext())
                {
                    RolOperation oRO = db.RolOperations.Find(id);
                    db.Remove(oRO);
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
