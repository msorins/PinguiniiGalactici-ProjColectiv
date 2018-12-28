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
    [RoutePrefix("groups")]
    public class GroupController : MainAPIController
    {
        //[Route("{userID:Guid}")] - example for Guid (Type must be specified)
        #region Methods
        [AuthenticationFilter]
        [HttpGet]
        [Route("")]
        //[AuthorizationFilter(Role.Administrator)]
        public IEnumerable<Group> ReadAll()
        {
            return BusinessContext.GroupBusiness.ReadAll();
        }

        [AuthenticationFilter]
        [HttpGet]
        [Route("{groupNumber:int}")]
        public Group ReadById(Int32 groupNumber)
        {
            return BusinessContext.GroupBusiness.ReadById(groupNumber);
        }

        [AuthenticationFilter]
        [HttpPost]
        [Route("")]
        public void Insert([FromBody]Group group)
        {
            BusinessContext.GroupBusiness.Insert(group);
        }

        [AuthenticationFilter]
        [HttpPut]
        [Route("")]
        public void Update([FromBody]Group group)
        {
            BusinessContext.GroupBusiness.Update(group);
        }

        [AuthenticationFilter]
        [HttpDelete]
        [Route("{groupNumber:int}")]
        public void Delete(Int32 groupNumber)
        {
            BusinessContext.GroupBusiness.Delete(groupNumber);
        }

        #endregion     
    }
}


