using Microsoft.IdentityModel.Tokens;
using PinguiniiGalactici.NewAcademicInfo.Business.Core;
using PinguiniiGalactici.NewAcademicInfo.Models;
using PinguiniiGalactici.NewAcademicInfo.Models.Utils;
using PinguiniiGalactici.NewAcademicInfo.WebAPI.Core;
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
    [RoutePrefix("token")]
    public class TokenController : MainAPIController
    {
        [AllowAnonymous]
        [HttpGet]
        [Route("")]
        public string GetToken()
        {
            string username = HttpContext.Current.Request.Params["username"];
            string password = HttpContext.Current.Request.Params["password"];

            if(username == null || password == null)
                throw new Exception("Unauthorized");

            BusinessContext context = new BusinessContext();
            User user = context.UserBusiness.ReadUser(username,password);
            if (user == null)
                throw new Exception("Unauthorized");

            return JwtTokenLibrary.GenerateToken(username, user.Role.ToString());
        }
    }
}
