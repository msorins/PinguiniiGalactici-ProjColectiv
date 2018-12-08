using Microsoft.IdentityModel.Tokens;
using PinguiniiGalactici.NewAcademicInfo.Models;
using PinguiniiGalactici.NewAcademicInfo.WebAPI.Core;
using PinguiniiGalactici.NewAcademicInfo.WebAPI.Filters;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web;
using System.Web.Http;

namespace PinguiniiGalactici.NewAcademicInfo.WebAPI.Controllers
{

    [RoutePrefix("users")]
    public class UserController : MainAPIController
    {
        //[Route("{userID:Guid}")] - example for Guid (type must be specified)
        #region Methods
      // // [AuthenticationFilter]
      //  [HttpGet]
      //  [Route("")]
      //  //[AuthorizationFilter(Role.Administrator)]
      //  public IEnumerable<User> ReadAll()
      //  {
      //      return BusinessContext.UserBusiness.ReadAll();
      //  }

      ////  [AuthenticationFilter]
      //  [HttpGet]
      //  [Route("{username}")]
      //  public User ReadByUsername(string username)
      //  {
      //      //return BusinessContext.UserBusiness.ReadByUsername(username);
      //  }

      // // [AuthenticationFilter]
      //  [HttpGet]
      //  [Route("ReadCurrentUserInfo")]
      //  public User ReadCurrentUserInfo()
      //  {
      //      return BusinessContext.CurrentUser;
      //  }

      ////  [AuthenticationFilter]
      //  [HttpPost]
      //  [Route("")]
      //  public void Insert([FromBody]User user)
      //  {
      //      //BusinessContext.UserBusiness.Insert(user);
      //  }

      // // [AuthenticationFilter]
      //  [HttpPut]
      //  [Route("")]
      //  public void Update([FromBody]User user)
      //  {
      //      //BusinessContext.UserBusiness.Update(user);
      //  }

      ////  [AuthenticationFilter]
      //  [HttpDelete]
      //  [Route("{username}")]
      //  public void Delete(string username)
      //  {
      //     // BusinessContext.UserBusiness.Delete(username);
      //  }

       // [AuthenticationFilter]
        [HttpPost]
        [Route("authenticate")]
        public string Authenticate()
        {
            // User sends his/hers username and password and if they match will receive json web token
            string username = HttpContext.Current.Request.Params["username"];
            string password = HttpContext.Current.Request.Params["password"];

            // To do, check in db if username && password are correct
            // If they are, generate the auth token
            return GenerateToken(username, 20);
        }
        #endregion
        
        private static bool ValidateToken(string token, out string username) // return true and the username if token was correct
        {
            username = null;

            var simplePrinciple = GetPrincipal(token);
            var identity = simplePrinciple.Identity as ClaimsIdentity;

            if (identity == null)
                return false;

            if (!identity.IsAuthenticated)
                return false;

            var usernameClaim = identity.FindFirst(ClaimTypes.Name);
            username = usernameClaim?.Value;

            if (string.IsNullOrEmpty(username))
                return false;

            // More validate to check whether username exists in system

            return true;
        }


        public static ClaimsPrincipal GetPrincipal(string token)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var jwtToken = tokenHandler.ReadToken(token) as JwtSecurityToken;

                if (jwtToken == null)
                    return null;

                var symmetricKey = Convert.FromBase64String(Secret);

                var validationParameters = new TokenValidationParameters()
                {
                    RequireExpirationTime = true,
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    IssuerSigningKey = new SymmetricSecurityKey(symmetricKey)
                };

                SecurityToken securityToken;
                var principal = tokenHandler.ValidateToken(token, validationParameters, out securityToken);

                return principal;
            }

            catch (Exception)
            {
  
                return null;
            }
        }
    }
}


