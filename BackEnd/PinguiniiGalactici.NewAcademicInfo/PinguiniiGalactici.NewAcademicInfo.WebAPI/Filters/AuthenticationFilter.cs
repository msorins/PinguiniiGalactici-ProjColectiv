using Newtonsoft.Json;
using PinguiniiGalactici.NewAcademicInfo.Business.Core;
using PinguiniiGalactici.NewAcademicInfo.Models;
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
            IPrincipal principal = context.ActionContext.RequestContext.Principal;

            if (principal == null || principal.Identity == null || !principal.Identity.IsAuthenticated)
            {
                throw new Exception("The user doesn't exist or is not authenticated!");
            }

            using (BusinessContext businessContext = new BusinessContext())
            {
                //User currentUser = businessContext.UserBusiness.ReadByUsername(principal.Identity.Name);
                //if (currentUser != null)
                //{
                    //claim based maybe :)) - depends on the received context (frontend authorizaton)
                  //  context.Principal = principal;
                    //return;
                //}
                throw new Exception("The user has no rights to authenticate!!");
            }
        }

        public async Task ChallengeAsync(HttpAuthenticationChallengeContext context,CancellationToken cancellationToken){ }
        #endregion
    }
}