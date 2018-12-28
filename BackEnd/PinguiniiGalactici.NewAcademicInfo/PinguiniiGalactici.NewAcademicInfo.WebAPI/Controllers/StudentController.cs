using PinguiniiGalactici.NewAcademicInfo.Models;
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
        //[AuthorizationFilter(Role.Administrator)]
        public IEnumerable<Student> ReadAll()
        {
            return BusinessContext.StudentsBusiness.ReadAll();
        }

      //  [AuthenticationFilter]
        [HttpGet]
        [Route("fromCourse/{CourseId:Guid}")]
        //[AuthorizationFilter(Role.Administrator)]
        public IEnumerable<Student> ReadAllFromCourse(Guid courseId)
        {
            return BusinessContext.StudentsBusiness.ReadAllFromCourse(courseId);
        }

       // [AuthenticationFilter]
        [HttpGet]
        [Route("{StudentsNumber:int}")]
        public Student ReadById(Int32 StudentsNumber)
        {
            return BusinessContext.StudentsBusiness.ReadById(StudentsNumber);
        }

       // [AuthenticationFilter]
        [HttpPost]
        [Route("")]
        public void Insert([FromBody]Student Students)
        {
            BusinessContext.StudentsBusiness.Insert(Students);
        }

      //  [AuthenticationFilter]
        [HttpPut]
        [Route("")]
        public void Update([FromBody]Student Students)
        {
            BusinessContext.StudentsBusiness.Update(Students);
        }

       // [AuthenticationFilter]
        [HttpDelete]
        [Route("{StudentsNumber:int}")]
        public void Delete(Int32 StudentsNumber)
        {
            BusinessContext.StudentsBusiness.Delete(StudentsNumber);
        }

        #endregion

        
    }
}


