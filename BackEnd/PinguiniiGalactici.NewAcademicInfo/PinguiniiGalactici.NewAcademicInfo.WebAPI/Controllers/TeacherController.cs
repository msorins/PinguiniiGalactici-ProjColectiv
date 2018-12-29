using Microsoft.IdentityModel.Tokens;
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
    [RoutePrefix("teachers")]
    public class TeacherController : MainAPIController
    {
        #region Methods
        [HttpGet]
        [Route("")]
        [AuthorizationFilter(Role.Admin,Role.Teacher, Role.Student)]
        public IEnumerable<Teacher> ReadAll()
        {
            return BusinessContext.TeachersBusiness.ReadAll();
        }

        [HttpGet]
        [Route("{TeachersNumber:Guid}")]
        [AuthorizationFilter(Role.Admin)]
        public Teacher ReadById(Guid TeachersNumber)
        {
            return BusinessContext.TeachersBusiness.ReadById(TeachersNumber);
        }

        [HttpPost]
        [Route("")]
        [AuthorizationFilter(Role.Admin)]
        public void Insert([FromBody]Teacher Teachers)
        {
            BusinessContext.TeachersBusiness.Insert(Teachers);
        }

        [HttpPut]
        [Route("")]
        [AuthorizationFilter(Role.Admin, Role.Teacher)]
        public void Update([FromBody]Teacher Teachers)
        {
            BusinessContext.TeachersBusiness.Update(Teachers);
        }

        [HttpDelete]
        [Route("{TeachersNumber:Guid}")]
        [AuthorizationFilter(Role.Admin)]
        public void Delete(Guid TeachersNumber)
        {
            BusinessContext.TeachersBusiness.Delete(TeachersNumber);
        }
        #endregion
    }
}


