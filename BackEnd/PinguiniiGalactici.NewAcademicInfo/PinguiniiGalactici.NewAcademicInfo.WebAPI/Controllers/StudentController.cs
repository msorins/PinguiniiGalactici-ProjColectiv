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

    [RoutePrefix("students")]
    public class StudentController : MainAPIController
    {
        //[Route("{userID:Guid}")] - example for Guid (Type must be specified)
        #region Methods
        [AuthenticationFilter]
        [HttpGet]
        [Route("")]
        //[AuthorizationFilter(Role.Administrator)]
        public IEnumerable<Student> ReadAll()
        {
            return BusinessContext.StudentsBusiness.ReadAll();
        }

        [AuthenticationFilter]
        [HttpGet]
        [Route("{StudentsNumber:int}")]
        public Student ReadById(Int32 StudentsNumber)
        {
            return BusinessContext.StudentsBusiness.ReadById(StudentsNumber);
        }

        [AuthenticationFilter]
        [HttpPost]
        [Route("")]
        public void Insert([FromBody]Student Students)
        {
            BusinessContext.StudentsBusiness.Insert(Students);
        }

        [AuthenticationFilter]
        [HttpPut]
        [Route("")]
        public void Update([FromBody]Student Students)
        {
            BusinessContext.StudentsBusiness.Update(Students);
        }

        [AuthenticationFilter]
        [HttpDelete]
        [Route("{StudentsNumber:int}")]
        public void Delete(Int32 StudentsNumber)
        {
            BusinessContext.StudentsBusiness.Delete(StudentsNumber);
        }

        #endregion

        
    }
}


