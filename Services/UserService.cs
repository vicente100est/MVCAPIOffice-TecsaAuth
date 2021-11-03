using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MVCAPIAuthenticationTecsaUser.Models.Common;
using MVCAPIAuthenticationTecsaUser.Models.Request;
using MVCAPIAuthenticationTecsaUser.Models.Response;
using MVCAPIAuthenticationTecsaUser.Moldels;
using MVCAPIAuthenticationTecsaUser.Tools;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MVCAPIAuthenticationTecsaUser.Services
{
    public class UserService : IUserService
    {
        private readonly AppSettings _appSettings;

        public UserService(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }
        public UserResponse Auth(AuthRequest model)
        {

            UserResponse userresponse = new UserResponse();
            using (var db = new tecsaofficeContext())
            {
                string sPassword = Encrypt.GetSHA256(model.Password_user);

                var usuario = db.Tecsausers.Where(d => d.EmailUser == model.Email_user &&
                                                    d.PasswordUser == sPassword).FirstOrDefault();
                if (usuario == null) return null;

                userresponse.Id_user = usuario.IdUser;
                userresponse.Email_user = usuario.EmailUser;
                userresponse.Token = GetToken(usuario);
            }
            return userresponse;
        }

        private string GetToken(Tecsauser usuario)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(
                    new Claim[]
                    {
                        new Claim(ClaimTypes.NameIdentifier, usuario.IdUser.ToString()),
                        new Claim(ClaimTypes.Email, usuario.EmailUser)
                    }
                    ),
                Expires = DateTime.UtcNow.AddDays(60),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
