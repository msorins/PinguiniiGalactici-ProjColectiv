using Newtonsoft.Json;
using PinguiniiGalactici.NewAcademicInfo.Business.Core;
using PinguiniiGalactici.NewAcademicInfo.Models;
using PinguiniiGalactici.NewAcademicInfo.WebAPI.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Filters;

namespace PinguiniiGalactici.NewAcademicInfo.WebAPI.Filters
{
    public class AuthenticationFilter : Attribute, IAuthenticationFilter
    {
        #region Properties
        public bool AllowMultiple
        {
            get { return false; }
        }
        #endregion

        #region Methods
        public async Task AuthenticateAsync(HttpAuthenticationContext context, CancellationToken cancellationToken)
        {
            var request = context.Request;
            var authorization = request.Headers.Authorization;

            if (authorization == null || authorization.Scheme != "Bearer")
                throw new Exception("Invalid scheme. Missing token parameter.");

            if (string.IsNullOrEmpty(authorization.Parameter))
            {
                throw new Exception("Missing token parameter.");
            }

            var token = authorization.Parameter;
            var principal = await AuthenticateJwtToken(token);

            if (principal == null)
                throw new Exception("Invalid token.");
            else
                context.Principal = principal;
        }

        protected Task<IPrincipal> AuthenticateJwtToken(string token)
        {
            IPrincipal principal;

            if (ValidateToken(token, out principal))
            { 
                return Task.FromResult(principal);
            }

            return Task.FromResult<IPrincipal>(null);
        }

        //toDo
        private bool ValidateToken(string token, out IPrincipal simplePrinciple)
        {
            string username = null;
            string role = null;

            simplePrinciple = JwtTokenLibrary.GetPrincipal(token);
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
            //get user by username from db would be nice :)

            var roleClaim = identity.FindFirst(ClaimTypes.Role);
            role = roleClaim?.Value;

            if (string.IsNullOrEmpty(role) && role.ToLower() !="admin" && role.ToLower() != "teacher" && role.ToLower() != "student")
                return false;

            return true;
        }

        public async Task ChallengeAsync(HttpAuthenticationChallengeContext context,CancellationToken cancellationToken){ }
        #endregion
    }
}