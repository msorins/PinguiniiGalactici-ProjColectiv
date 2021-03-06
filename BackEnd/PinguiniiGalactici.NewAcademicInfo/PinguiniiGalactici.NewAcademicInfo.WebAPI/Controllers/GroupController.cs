﻿using Microsoft.IdentityModel.Tokens;
using PinguiniiGalactici.NewAcademicInfo.Models;
using PinguiniiGalactici.NewAcademicInfo.Models.Enumerations;
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
    [AuthenticationFilter]
    [RoutePrefix("groups")]
    public class GroupController : MainAPIController
    {
        #region Methods
        [HttpGet]
        [Route("")]
        [AuthorizationFilter(Role.Admin, Role.Teacher, Role.Student)]
        public IEnumerable<Group> ReadAll()
        {
            return BusinessContext.GroupBusiness.ReadAll();
        }

        [HttpGet]
        [Route("{groupNumber:int}")]
        [AuthorizationFilter(Role.Admin)]
        public Group ReadById(Int32 groupNumber)
        {
            return BusinessContext.GroupBusiness.ReadById(groupNumber);
        }

        [HttpPost]
        [Route("")]
        [AuthorizationFilter(Role.Admin)]
        public void Insert([FromBody]Group group)
        {
            BusinessContext.GroupBusiness.Insert(group);
        }

        [HttpPut]
        [Route("")]
        [AuthorizationFilter(Role.Admin)]
        public void Update([FromBody]Group group)
        {
            BusinessContext.GroupBusiness.Update(group);
        }

        [HttpDelete]
        [Route("{groupNumber:int}")]
        [AuthorizationFilter(Role.Admin)]
        public void Delete(Int32 groupNumber)
        {
            BusinessContext.GroupBusiness.Delete(groupNumber);
        }
        #endregion     
    }
}


