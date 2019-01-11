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
    [RoutePrefix("courses")]
    public class CourseController : MainAPIController
    {
        #region Methods
        [HttpGet]
        [Route("")]
        [AuthorizationFilter(Role.Admin, Role.Teacher, Role.Student)]
        public IEnumerable<Course> ReadAll()
        {
            return BusinessContext.CoursesBusiness.ReadAll();
        }

        [HttpGet]
        [Route("forTeacher/{TeacherID:Guid}")]
        [AuthorizationFilter(Role.Admin, Role.Teacher, Role.Student)]
        public IEnumerable<Course> ReadAllForTeacher(Guid TeacherID)
        {
            return BusinessContext.CoursesBusiness.ReadAllForTeacher(TeacherID);
        }

        [HttpGet]
        [Route("{CoursesNumber:Guid}")]
        [AuthorizationFilter(Role.Admin)]
        public Course ReadById(Guid CoursesNumber)
        {
            return BusinessContext.CoursesBusiness.ReadById(CoursesNumber);
        }

        [HttpPost]
        [Route("")]
        [AuthorizationFilter(Role.Admin)]
        public void Insert([FromBody]Course Courses)
        {
            BusinessContext.CoursesBusiness.Insert(Courses);
        }

        [HttpPut]
        [Route("")]
        [AuthorizationFilter(Role.Admin)]
        public void Update([FromBody]Course Courses)
        {
            BusinessContext.CoursesBusiness.Update(Courses);
        }

        [HttpDelete]
        [Route("{CoursesNumber:Guid}")]
        [AuthorizationFilter(Role.Admin)]
        public void Delete(Guid CoursesNumber)
        {
            BusinessContext.CoursesBusiness.Delete(CoursesNumber);
        }
        #endregion
    }
}


