using PinguiniiGalactici.NewAcademicInfo.Models;
using PinguiniiGalactici.NewAcademicInfo.WebAPI.Core;
using PinguiniiGalactici.NewAcademicInfo.WebAPI.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PinguiniiGalactici.NewAcademicInfo.WebAPI.Controllers
{
    [AuthenticationFilter]
    [RoutePrefix("users")]
    public class UserController : MainAPIController
    {
        //[Route("{userID:Guid}")] - example for Guid (type must be specified)
        #region Methods
        [HttpGet]
        [Route("")]
        //[AuthorizationFilter(Role.Administrator)]
        public IEnumerable<User> ReadAll()
        {
            return BusinessContext.UserBusiness.ReadAll();
        }

        [HttpGet]
        [Route("{username}")]
        public User ReadByUsername(string username)
        {
            return BusinessContext.UserBusiness.ReadByUsername(username);
        }

        [HttpGet]
        [Route("ReadCurrentUserInfo")]
        public User ReadCurrentUserInfo()
        {
            return BusinessContext.CurrentUser;
        }

        [HttpPost]
        [Route("")]
        public void Insert([FromBody]User user)
        {
            BusinessContext.UserBusiness.Insert(user);
        }

        [HttpPut]
        [Route("")]
        public void Update([FromBody]User user)
        {
            BusinessContext.UserBusiness.Update(user);
        }

        [HttpDelete]
        [Route("{username}")]
        public void Delete(string username)
        {
            BusinessContext.UserBusiness.Delete(username);
        }
        #endregion
    }
}
