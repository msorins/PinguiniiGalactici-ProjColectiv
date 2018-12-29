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
        private readonly string[] _roles;
        #endregion

        #region Constructors
        public AuthorizationFilter(params object[] roles)
            : base()
        {
            if (roles.Any(p => p.GetType().BaseType != typeof(Enum)))
                throw new ArgumentException("Invalid role types!");

            _roles = roles.Select(p => Enum.GetName(p.GetType(), p)).ToArray();
        }
        #endregion

        #region Methods
        protected override bool IsAuthorized(HttpActionContext actionContext)
        {
            foreach (var role in _roles)
                if (actionContext.RequestContext.Principal.IsInRole(role.ToString()))
                    return true;
            return false;           
        }
        #endregion
    }
}