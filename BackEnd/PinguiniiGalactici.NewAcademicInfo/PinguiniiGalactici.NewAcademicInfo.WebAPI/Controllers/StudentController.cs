using PinguiniiGalactici.NewAcademicInfo.Models;
using PinguiniiGalactici.NewAcademicInfo.Models.Enumerations;
using PinguiniiGalactici.NewAcademicInfo.WebAPI.Core;
using PinguiniiGalactici.NewAcademicInfo.WebAPI.Filters;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace PinguiniiGalactici.NewAcademicInfo.WebAPI.Controllers
{
    [AuthenticationFilter]
    [RoutePrefix("students")]
    public class StudentController : MainAPIController
    {
        #region Methods
        [HttpGet]
        [Route("")]
        [AuthorizationFilter(Role.Admin,Role.Teacher,Role.Student)]
        public IEnumerable<Student> ReadAll()
        {
            return BusinessContext.StudentsBusiness.ReadAll();
        }

        [HttpGet]
        [Route("fromCourse/{CourseId:Guid}")]
        [AuthorizationFilter(Role.Admin,Role.Teacher)]
        public IEnumerable<Student> ReadAllFromCourse(Guid courseId)
        {
            return BusinessContext.StudentsBusiness.ReadAllFromCourse(courseId);
        }

        [HttpGet]
        [Route("{StudentsNumber:int}")]
        [AuthorizationFilter(Role.Admin)]
        public Student ReadById(Int32 StudentsNumber)
        {
            return BusinessContext.StudentsBusiness.ReadById(StudentsNumber);
        }

        [HttpPost]
        [Route("")]
        [AuthorizationFilter(Role.Admin)]
        public void Insert([FromBody]Student Students)
        {
            BusinessContext.StudentsBusiness.Insert(Students);
        }

        [AuthorizationFilter(Role.Admin)]
        [HttpPut]
        [Route("")]
        public void Update([FromBody]Student Students)
        {
            BusinessContext.StudentsBusiness.Update(Students);
        }

        [HttpDelete]
        [Route("{StudentsNumber:int}")]
        [AuthorizationFilter(Role.Admin)]
        public void Delete(Int32 StudentsNumber)
        {
            BusinessContext.StudentsBusiness.Delete(StudentsNumber);
        }
        #endregion
    }
}


