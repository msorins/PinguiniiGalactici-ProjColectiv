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
    [AuthenticationFilter]
    [RoutePrefix("courses")]
    public class CourseController : MainAPIController
    {
        #region Methods
        [HttpGet]
        [Route("")]
        //[AuthorizationFilter(Role.Administrator)]
        public IEnumerable<Course> ReadAll()
        {
            return BusinessContext.CoursesBusiness.ReadAll();
        }

       // [AuthenticationFilter]
        [HttpGet]
        [Route("{CoursesNumber:Guid}")]
        public Course ReadById(Guid CoursesNumber)
        {
            return BusinessContext.CoursesBusiness.ReadById(CoursesNumber);
        }

        [HttpPost]
        [Route("")]
        public void Insert([FromBody]Course Courses)
        {
            BusinessContext.CoursesBusiness.Insert(Courses);
        }

        [HttpPut]
        [Route("")]
        public void Update([FromBody]Course Courses)
        {
            BusinessContext.CoursesBusiness.Update(Courses);
        }

        [HttpDelete]
        [Route("{CoursesNumber:Guid}")]
        public void Delete(Guid CoursesNumber)
        {
            BusinessContext.CoursesBusiness.Delete(CoursesNumber);
        }
        #endregion
    }
}


