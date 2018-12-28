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

    [RoutePrefix("departments")]
    public class DepartmentController : MainAPIController
    {
        //[Route("{userID:Guid}")] - example for Guid (Type must be specified)
        #region Methods
        [AuthenticationFilter]
        [HttpGet]
        [Route("")]
        //[AuthorizationFilter(Role.Administrator)]
        public IEnumerable<Department> ReadAll()
        {
            return BusinessContext.DepartmentBusiness.ReadAll();
        }

        [AuthenticationFilter]
        [HttpGet]
        [Route("{departmentID:Guid}")]
        public Department ReadById(Guid departmentID)
        {
            return BusinessContext.DepartmentBusiness.ReadById(departmentID);
        }

        [AuthenticationFilter]
        [HttpPost]
        [Route("")]
        public void Insert([FromBody]Department department)
        {
            BusinessContext.DepartmentBusiness.Insert(department);
        }

        [AuthenticationFilter]
        [HttpPut]
        [Route("")]
        public void Update([FromBody]Department department)
        {
            BusinessContext.DepartmentBusiness.Update(department);
        }

        [AuthenticationFilter]
        [HttpDelete]
        [Route("{departmentID:Guid}")]
        public void Delete(Guid departmentID)
        {
            BusinessContext.DepartmentBusiness.Delete(departmentID);
        }

        #endregion     
    }
}


