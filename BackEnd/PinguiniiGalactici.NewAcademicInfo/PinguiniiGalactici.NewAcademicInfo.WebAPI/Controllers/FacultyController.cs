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
    [RoutePrefix("faculties")]
    public class FacultyController : MainAPIController
    {
        //[Route("{userID:Guid}")] - example for Guid (type must be specified)
        #region Methods
        //[AuthenticationFilter]
        [HttpGet]
        [Route("")]
        //[AuthorizationFilter(Role.Administrator)]
        public IEnumerable<Faculty> ReadAll()
        {
            return BusinessContext.FacultyBusiness.ReadAll();
        }

        //[AuthenticationFilter]
        [HttpGet]
        [Route("{facultyID:Guid}")]
        public Faculty ReadById(Guid facultyID)
        {
            return BusinessContext.FacultyBusiness.ReadById(facultyID);
        }

        //[AuthenticationFilter]
        [HttpPost]
        [Route("")]
        public void Insert([FromBody]Faculty faculty)
        {
            BusinessContext.FacultyBusiness.Insert(faculty);
        }

        [AuthenticationFilter]
        [HttpPut]
        [Route("")]
        public void Update([FromBody]Faculty faculty)
        {
            BusinessContext.FacultyBusiness.Update(faculty);
        }

        //[AuthenticationFilter]
        [HttpDelete]
        [Route("{facultyID:Guid}")]
        public void Delete(Guid facultyId)
        {
            BusinessContext.FacultyBusiness.Delete(facultyId);
        }

        #endregion    
    }
}


