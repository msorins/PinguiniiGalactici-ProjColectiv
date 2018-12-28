using PinguiniiGalactici.NewAcademicInfo.Business.Core;
using PinguiniiGalactici.NewAcademicInfo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;

namespace PinguiniiGalactici.NewAcademicInfo.WebAPI.Core
{
    public class MainAPIController : ApiController
    {
        #region Members
        private BusinessContext _businessContext;
        #endregion

        #region Properties
        public BusinessContext BusinessContext
        {
            get
            {
                if (_businessContext == null)
                {
                    _businessContext = GetAuthenticatedBusinessContext();
                    if (_businessContext == null)
                        throw new Exception("Unauthorized access!");
                }
                return _businessContext;
            }
        }
        #endregion

       #region Methods
        private BusinessContext GetAuthenticatedBusinessContext()
        {
            ClaimsIdentity currentIdentity = (ClaimsIdentity)RequestContext.Principal.Identity;
            if (currentIdentity == null)
                return null;

            var usernameClaim = currentIdentity.FindFirst(ClaimTypes.Name);
            string username = usernameClaim?.Value;

            if (string.IsNullOrEmpty(username))
                return null;

            var passwordClaim = currentIdentity.FindFirst(ClaimValueTypes.Rsa);
            string password = passwordClaim?.Value;

            if (string.IsNullOrEmpty(password))
                return null;

            string decryptedPassword = RsaEncryption.Decryption(password);

            var roleClaim = currentIdentity.FindFirst(ClaimTypes.Role);
            string role = roleClaim?.Value;

            if (string.IsNullOrEmpty(role) && role.ToLower() != "admin" && role.ToLower() != "teacher" && role.ToLower() != "student")
                return null;

            User authenticatedUser = new User()
            {
                Username = username,
                Password = decryptedPassword,
                Role = role.ToLower().Equals("admin") ? Models.Enumerations.Role.Admin :
                       role.ToLower().Equals("teacher") ? Models.Enumerations.Role.Teacher :
                       Models.Enumerations.Role.Student
            };

            return new BusinessContext(authenticatedUser);
        }
        #endregion

        #region IDisposable
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_businessContext != null)
                {
                    _businessContext.Dispose();
                    _businessContext = null;
                }
            }
            base.Dispose(disposing);
        }
        #endregion
    }
}
