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
    public class WorkerTaskController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetWorkerTask()
        {
            Answer oAnswer = new Answer();
            oAnswer.Successful = 0;
            try
            {
                using (tecsaofficeContext db = new tecsaofficeContext())
                {
                    var workerTask =
                        from tu in db.Tecsausers
                        from tk in db.WorkinTecsausers
                        from tt in db.Workings
                        where tu.IdUser == tk.IdUser && tk.IdWork == tt.IdWork
                        select new
                        {
                            tk.IdWt,
                            tt.TitleWork,
                            tu.NameUser
                        };

                    oAnswer.Successful = 1;
                    oAnswer.Data = workerTask.ToList();
                }
            }
            catch (Exception ex)
            {
                oAnswer.Message = ex.Message;
            }

            return Ok(oAnswer);
        }

        [HttpGet("specific/{id}")]
        public IActionResult GetWorkerTaskSpecific(int id)
        {
            Answer oAnswer = new Answer();
            oAnswer.Successful = 0;
            try
            {
                using (tecsaofficeContext db = new tecsaofficeContext())
                {
                    var workerTask =
                        from tu in db.Tecsausers
                        from tk in db.WorkinTecsausers
                        from tt in db.Workings
                        where tu.IdUser == tk.IdUser && tk.IdWork == tt.IdWork
                        select new
                        {
                            tk.IdWt,
                            tt.TitleWork,
                            tu.NameUser
                        };

                    oAnswer.Successful = 1;
                    oAnswer.Data = workerTask.FirstOrDefault(x => x.IdWt == id);
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
