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
    [RoutePrefix("gradeTypes")]
    public class GradeTypeController : MainAPIController
    {
        #region Methods
        [HttpGet]
        [Route("")]
        [AuthorizationFilter(Role.Admin, Role.Teacher, Role.Student)]
        public IEnumerable<Models.GradeType> ReadAll()
        {
            return BusinessContext.TypesBusiness.ReadAll();
        }

        [HttpGet]
        [Route("{TypesNumber:Guid}")]
        [AuthorizationFilter(Role.Admin)]
        public GradeType ReadById(Guid TypesNumber)
        {
            return BusinessContext.TypesBusiness.ReadById(TypesNumber);
        }

        [HttpPost]
        [Route("")]
        [AuthorizationFilter(Role.Admin)]
        public void Insert([FromBody] Models.GradeType Types)
        {
            BusinessContext.TypesBusiness.Insert(Types);
        }

        [HttpPut]
        [Route("")]
        [AuthorizationFilter(Role.Admin)]
        public void Update([FromBody] Models.GradeType Types)
        {
            BusinessContext.TypesBusiness.Update(Types);
        }

        [HttpDelete]
        [Route("{TypesNumber:Guid}")]
        [AuthorizationFilter(Role.Admin)]
        public void Delete(Guid TypesNumber)
        {
            BusinessContext.TypesBusiness.Delete(TypesNumber);
        }

        #endregion
    }
}


