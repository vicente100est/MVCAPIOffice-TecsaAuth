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
    public class TaskController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetTask()
        {
            Answer oAnswer = new Answer();
            oAnswer.Successful = 0;
            try
            {
                using (tecsaofficeContext db = new tecsaofficeContext())
                {
                    var taskRol = db.Workings.Join(
                        db.Rols,
                        tk => tk.IdRol,
                        rl => rl.IdRol,
                        (tk, rl) =>
                            new
                            {
                                tk.IdWork,
                                tk.TitleWork,
                                tk.DescriptionWork,
                                tk.StatusWork,
                                rl.Name
                            }).ToList();

                    oAnswer.Successful = 1;
                    oAnswer.Data = taskRol;
                }
            }
            catch (Exception ex)
            {
                oAnswer.Message = ex.Message;
            }

            return Ok(oAnswer);
        }

        [HttpGet("specific/{id}")]
        public IActionResult GetTaskSpecific(int id)
        {
            Answer oAnswer = new Answer();
            oAnswer.Successful = 0;
            try
            {
                using (tecsaofficeContext db = new tecsaofficeContext())
                {
                    var taskRol = db.Workings.Join(
                        db.Rols,
                        tk => tk.IdRol,
                        rl => rl.IdRol,
                        (tk, rl) =>
                            new
                            {
                                tk.IdWork,
                                tk.TitleWork,
                                tk.DescriptionWork,
                                tk.StatusWork,
                                rl.Name
                            }).FirstOrDefault(x => x.IdWork == id);

                    oAnswer.Successful = 1;
                    oAnswer.Data = taskRol;
                }
            }
            catch (Exception ex)
            {
                oAnswer.Message = ex.Message;
            }

            return Ok(oAnswer);
        }

        [HttpGet("Checking")]
        public IActionResult GetTaskChecking()
        {
            Answer oAnswer = new Answer();
            oAnswer.Successful = 0;
            try
            {
                using (tecsaofficeContext db = new tecsaofficeContext())
                {
                    var taskRol = db.Workings.Join(
                        db.Rols,
                        tk => tk.IdRol,
                        rl => rl.IdRol,
                        (tk, rl) =>
                            new
                            {
                                tk.IdWork,
                                tk.TitleWork,
                                tk.DescriptionWork,
                                tk.StatusWork,
                                rl.Name
                            }).FirstOrDefault(x => x.StatusWork == "checking");

                    oAnswer.Successful = 1;
                    oAnswer.Data = taskRol;
                }
            }
            catch (Exception ex)
            {
                oAnswer.Message = ex.Message;
            }

            return Ok(oAnswer);
        }

        [HttpGet("Checking/specific/{id}")]
        public IActionResult GetTaskChecking(int id)
        {
            Answer oAnswer = new Answer();
            oAnswer.Successful = 0;
            try
            {
                using (tecsaofficeContext db = new tecsaofficeContext())
                {
                    var taskRol = db.Workings.Join(
                        db.Rols,
                        tk => tk.IdRol,
                        rl => rl.IdRol,
                        (tk, rl) =>
                            new
                            {
                                tk.IdWork,
                                tk.TitleWork,
                                tk.DescriptionWork,
                                tk.StatusWork,
                                rl.Name
                            }).FirstOrDefault(x => x.StatusWork == "checking" && x.IdWork == id);

                    oAnswer.Successful = 1;
                    oAnswer.Data = taskRol;
                }
            }
            catch (Exception ex)
            {
                oAnswer.Message = ex.Message;
            }

            return Ok(oAnswer);
        }

        [HttpGet("User/{idUser}")]
        public IActionResult GetTaskUser(int idUser)
        {
            Answer oAnswer = new Answer();
            oAnswer.Successful = 0;
            try
            {
                using(tecsaofficeContext db = new tecsaofficeContext())
                {
                    var taskUserRol = (
                        from tk in db.Workings
                        from rl in db.Rols
                        from tu in db.Tecsausers
                        where tu.IdUser == idUser && tu.IdRol == rl.IdRol && rl.IdRol == tk.IdRol
                            && tk.StatusWork == "ToDo"
                        select new
                        {
                            tk.IdWork,
                            tk.TitleWork,
                            tk.DescriptionWork,
                            tk.StatusWork
                        }).ToList();

                    oAnswer.Successful = 1;
                    oAnswer.Data = taskUserRol;
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
