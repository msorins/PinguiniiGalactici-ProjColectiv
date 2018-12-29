using PinguiniiGalactici.NewAcademicInfo.Models;
using PinguiniiGalactici.NewAcademicInfo.Models.Enumerations;
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
    [RoutePrefix("studentsCourses")]
    public class StudentCourseController : MainAPIController
    {
        #region Methods
        [HttpGet]
        [Route("")]
        [AuthorizationFilter(Role.Admin, Role.Teacher)]
        public IEnumerable<StudentCourse> ReadAll()
        {
            return BusinessContext.StudentCourseBusiness.ReadAll();
        }

        [HttpGet]
        [Route("{EnrollmentID:Guid}")]
        [AuthorizationFilter(Role.Admin)]
        public StudentCourse ReadById(Guid EnrollmentID)
        {
            return BusinessContext.StudentCourseBusiness.ReadById(EnrollmentID);
        }

        [HttpPost]
        [Route("")]
        [AuthorizationFilter(Role.Admin)]
        public void Insert([FromBody]StudentCourse StudentCourse)
        {
            BusinessContext.StudentCourseBusiness.Insert(StudentCourse);
        }

        [AuthorizationFilter(Role.Admin)]
        [HttpPut]
        [Route("")]
        public void Update([FromBody]StudentCourse StudentCourse)
        {
            BusinessContext.StudentCourseBusiness.Update(StudentCourse);
        }

        [HttpDelete]
        [Route("{EnrollmentID:Guid}")]
        [AuthorizationFilter(Role.Admin)]
        public void Delete(Guid EnrollmentID)
        {
            BusinessContext.StudentCourseBusiness.Delete(EnrollmentID);
        }
        #endregion
    }
}
