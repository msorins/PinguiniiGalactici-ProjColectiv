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

    [RoutePrefix("gradeTypes")]
    public class GradeTypeController : MainAPIController
    {
        //[Route("{userID:Guid}")] - example for Guid (Type must be specified)
        #region Methods
        [AuthenticationFilter]
        [HttpGet]
        [Route("")]
        //[AuthorizationFilter(Role.Administrator)]
        public IEnumerable<Models.GradeType> ReadAll()
        {
            return BusinessContext.TypesBusiness.ReadAll();
        }

        [AuthenticationFilter]
        [HttpGet]
        [Route("{TypesNumber:Guid}")]
        public GradeType ReadById(Guid TypesNumber)
        {
            return BusinessContext.TypesBusiness.ReadById(TypesNumber);
        }

        [AuthenticationFilter]
        [HttpPost]
        [Route("")]
        public void Insert([FromBody] Models.GradeType Types)
        {
            BusinessContext.TypesBusiness.Insert(Types);
        }

        [AuthenticationFilter]
        [HttpPut]
        [Route("")]
        public void Update([FromBody] Models.GradeType Types)
        {
            BusinessContext.TypesBusiness.Update(Types);
        }

        [AuthenticationFilter]
        [HttpDelete]
        [Route("{TypesNumber:Guid}")]
        public void Delete(Guid TypesNumber)
        {
            BusinessContext.TypesBusiness.Delete(TypesNumber);
        }

        #endregion


    }
}


