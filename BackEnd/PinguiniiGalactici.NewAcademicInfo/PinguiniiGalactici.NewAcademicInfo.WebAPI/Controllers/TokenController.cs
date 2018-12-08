using Microsoft.IdentityModel.Tokens;
using PinguiniiGalactici.NewAcademicInfo.Business.Core;
using PinguiniiGalactici.NewAcademicInfo.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web;
using System.Web.Http;

namespace PinguiniiGalactici.NewAcademicInfo.WebAPI.Controllers
{
    [RoutePrefix("")]
    public class TokenController : ApiController
    {
        private const string Secret = "ab3OIsj+BXE9NZDy0t8W3TcNekrF+2d/1sFnWG4HnV8TZY30iTOdtVWJG8abWvB1GlOgJuQZdcF2Luqm/hccMw==";

        [HttpGet]
        [Route("getToken")]
        public static string GenerateToken()
        {
            string username;
            string password;
            try
            {
                username = HttpContext.Current.Request.Params["username"];
                password = HttpContext.Current.Request.Params["password"];
            }
            catch(Exception ex)
            {
                return String.Empty;
            }

            BusinessContext context = new BusinessContext();
            string connectionString = "";
            User user = context.UserBusiness.ReadUser(connectionString,username,password);
            if (user == null)
                return String.Empty;

            var symmetricKey = Convert.FromBase64String(Secret);
            var tokenHandler = new JwtSecurityTokenHandler();

            var now = DateTime.UtcNow;
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                   new Claim(ClaimTypes.Name, username)
                }),

                Expires = now.AddMinutes(Convert.ToInt32(20)),

                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(symmetricKey), SecurityAlgorithms.HmacSha256Signature)
            };

            var stoken = tokenHandler.CreateToken(tokenDescriptor);
            var token = tokenHandler.WriteToken(stoken);

            return token;
        }
    }

}
