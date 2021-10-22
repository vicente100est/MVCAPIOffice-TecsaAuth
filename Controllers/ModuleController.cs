using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVCAPIAuthenticationTecsaUser.Moldels;
using MVCAPIAuthenticationTecsaUser.Models.Response;
using MVCAPIAuthenticationTecsaUser.Models.Request;

namespace MVCAPIAuthenticationTecsaUser.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModuleController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetModules()
        {
            Answer oAnswer = new Answer();
            oAnswer.Successful = 0;
            using (tecsaofficeContext db = new tecsaofficeContext())
            {
                try
                {
                    var lst = db.Modules.ToList();
                    oAnswer.Successful = 1;
                    oAnswer.Data = lst;
                }
                catch (Exception ex)
                {
                    oAnswer.Message = ex.Message;
                }

                return Ok(oAnswer);
            }
        }
        [HttpPost]
        public IActionResult AddModules(ModuleRequest oModel)
        {
            Answer oAnswer = new Answer();
            oAnswer.Successful = 0;
            try
            {
                using(tecsaofficeContext db = new tecsaofficeContext())
                {
                    Module oModule = new Module();
                    oModule.NameModule = oModel.Name_module;
                    db.Modules.Add(oModule);
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
        [HttpPut]
        public IActionResult UpDateModule(ModuleRequest oModel)
        {
            Answer oAnswer = new Answer();
            oAnswer.Successful = 0;
            try
            {
                using (tecsaofficeContext db = new tecsaofficeContext())
                {
                    Module oModule = db.Modules.Find(oModel.Id_module);
                    oModule.NameModule = oModel.Name_module;
                    db.Entry(oModule).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
        public IActionResult DelateModule(int id)
        {
            Answer oAnswer = new Answer();
            oAnswer.Successful = 0;
            try
            {
                using (tecsaofficeContext db = new tecsaofficeContext())
                {
                    Module oModule = db.Modules.Find(id);
                    db.Remove(oModule);
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
