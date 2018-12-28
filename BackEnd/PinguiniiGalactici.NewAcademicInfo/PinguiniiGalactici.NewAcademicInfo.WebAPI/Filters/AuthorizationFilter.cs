using PinguiniiGalactici.NewAcademicInfo.Models.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace PinguiniiGalactici.NewAcademicInfo.WebAPI.Filters
{
    public class AuthorizationFilter : AuthorizeAttribute
    {
        #region Members
        private readonly Role _role;
        #endregion

        #region Constructors
        public AuthorizationFilter(Role role)
            : base()
        {
            _role = role;
        }
        #endregion

        #region Methods
        protected override bool IsAuthorized(HttpActionContext actionContext)
        {
            return actionContext.RequestContext.Principal.IsInRole(_role.ToString());            
        }
        #endregion
    }
}