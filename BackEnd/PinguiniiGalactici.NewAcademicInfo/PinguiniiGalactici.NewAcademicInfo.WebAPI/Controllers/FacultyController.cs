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
    [RoutePrefix("faculties")]
    public class FacultyController : MainAPIController
    {
        #region Methods
        [HttpGet]
        [Route("")]
        [AuthorizationFilter(Role.Admin, Role.Teacher)]
        public IEnumerable<Faculty> ReadAll()
        {
            return BusinessContext.FacultyBusiness.ReadAll();
        }

        [HttpGet]
        [Route("{facultyID:Guid}")]
        [AuthorizationFilter(Role.Admin)]
        public Faculty ReadById(Guid facultyID)
        {
            return BusinessContext.FacultyBusiness.ReadById(facultyID);
        }

        [HttpPost]
        [Route("")]
        [AuthorizationFilter(Role.Admin)]
        public void Insert([FromBody]Faculty faculty)
        {
            BusinessContext.FacultyBusiness.Insert(faculty);
        }

        [HttpPut]
        [Route("")]
        [AuthorizationFilter(Role.Admin)]
        public void Update([FromBody]Faculty faculty)
        {
            BusinessContext.FacultyBusiness.Update(faculty);
        }

        [HttpDelete]
        [Route("{facultyID:Guid}")]
        [AuthorizationFilter(Role.Admin)]
        public void Delete(Guid facultyId)
        {
            BusinessContext.FacultyBusiness.Delete(facultyId);
        }

        #endregion    
    }
}


