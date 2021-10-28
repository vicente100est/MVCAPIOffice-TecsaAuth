using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVCAPIAuthenticationTecsaUser.Models.Request;
using MVCAPIAuthenticationTecsaUser.Models.Response;
using MVCAPIAuthenticationTecsaUser.Services;
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
    }
}
