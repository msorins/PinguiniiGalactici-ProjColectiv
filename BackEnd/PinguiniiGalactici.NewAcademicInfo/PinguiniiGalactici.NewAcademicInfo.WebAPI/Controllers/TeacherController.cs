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
    [RoutePrefix("teachers")]
    public class TeacherController : MainAPIController
    {
        //[Route("{userID:Guid}")] - example for Guid (Type must be specified)
        #region Methods
        [HttpGet]
        [Route("")]
        //[AuthorizationFilter(Role.Administrator)]
        public IEnumerable<Teacher> ReadAll()
        {
            return BusinessContext.TeachersBusiness.ReadAll();
        }

        [HttpGet]
        [Route("{TeachersNumber:Guid}")]
        public Teacher ReadById(Guid TeachersNumber)
        {
            return BusinessContext.TeachersBusiness.ReadById(TeachersNumber);
        }

       // [AuthenticationFilter]
        [HttpPost]
        [Route("")]
        public void Insert([FromBody]Teacher Teachers)
        {
            BusinessContext.TeachersBusiness.Insert(Teachers);
        }

     //   [AuthenticationFilter]
        [HttpPut]
        [Route("")]
        public void Update([FromBody]Teacher Teachers)
        {
            BusinessContext.TeachersBusiness.Update(Teachers);
        }

      //  [AuthenticationFilter]
        [HttpDelete]
        [Route("{TeachersNumber:Guid}")]
        public void Delete(Guid TeachersNumber)
        {
            BusinessContext.TeachersBusiness.Delete(TeachersNumber);
        }

        #endregion


    }
}


