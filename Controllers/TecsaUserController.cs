using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVCAPIAuthenticationTecsaUser.Models.Request;
using MVCAPIAuthenticationTecsaUser.Models.Response;
using MVCAPIAuthenticationTecsaUser.Moldels;
using MVCAPIAuthenticationTecsaUser.Services;
using MVCAPIAuthenticationTecsaUser.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCAPIAuthenticationTecsaUser.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TecsaUserController : ControllerBase
    {
        private IUserService _userService;

        public TecsaUserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("login")]
        public IActionResult Authenticate([FromBody] AuthRequest oModel)
        {
            Answer oAnswer = new Answer();

            var userresponse = _userService.Auth(oModel);

            if (userresponse == null)
            {
                oAnswer.Successful = 0;
                oAnswer.Message = "Incorrect user or password";
                return BadRequest(oAnswer);
            }

            oAnswer.Successful = 1;
            oAnswer.Data = userresponse;

            return Ok(oAnswer);
        }

        [HttpPost("adduser")]
        public IActionResult AddTecsaUser(TecsaUserRequest oModel)
        {
            DateTime now = DateTime.Today;
            Answer oAnswer = new Answer();
            oAnswer.Successful = 0;
            try
            {
                using(tecsaofficeContext db = new tecsaofficeContext())
                {
                    Tecsauser oTU = new Tecsauser();
                    oTU.IdUser = oModel.Id_user;
                    oTU.NameUser = oModel.Name_user;
                    oTU.EmailUser = oModel.Email_user;
                    oTU.PasswordUser = Encrypt.GetSHA256(oModel.Password_user);
                    oTU.DateUser = now;
                    oTU.IdRol = oModel.Id_rol;
                    db.Tecsausers.Add(oTU);
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

        [HttpPut("adduser/{id}")]
        public IActionResult UpDateTecsaUser(int id, TecsaUserRequest oModel)
        {
            DateTime now = DateTime.Today;
            Answer oAnswer = new Answer();
            oAnswer.Successful = 0;
            try
            {
                using (tecsaofficeContext db = new tecsaofficeContext())
                {
                    Tecsauser oTU = db.Tecsausers.Find(id);
                    oTU.NameUser = oModel.Name_user;
                    oTU.EmailUser = oModel.Email_user;
                    oTU.PasswordUser = Encrypt.GetSHA256(oModel.Password_user);
                    oTU.DateUser = now;
                    oTU.IdRol = oModel.Id_rol;
                    db.Entry(oTU).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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

        [HttpDelete("delateuser/{id}")]
        public IActionResult DelateTecsaUser(int id)
        {
            Answer oAnswer = new Answer();
            oAnswer.Successful = 0;
            try
            {
                using (tecsaofficeContext db = new tecsaofficeContext())
                {
                    Tecsauser oTU = db.Tecsausers.Find(id);
                    db.Remove(oTU);
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
