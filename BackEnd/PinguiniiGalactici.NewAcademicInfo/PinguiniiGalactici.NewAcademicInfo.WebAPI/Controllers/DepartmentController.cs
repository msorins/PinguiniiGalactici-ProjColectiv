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
    [RoutePrefix("departments")]
    public class DepartmentController : MainAPIController
    {
        #region Methods     
        [HttpGet]
        [Route("")]
        [AuthorizationFilter(Role.Admin, Role.Teacher)]
        public IEnumerable<Department> ReadAll()
        {
            return BusinessContext.DepartmentBusiness.ReadAll();
        }

        [HttpGet]
        [Route("{departmentID:Guid}")]
        [AuthorizationFilter(Role.Admin)]
        public Department ReadById(Guid departmentID)
        {
            return BusinessContext.DepartmentBusiness.ReadById(departmentID);
        }

        [HttpPost]
        [Route("")]
        [AuthorizationFilter(Role.Admin)]
        public void Insert([FromBody]Department department)
        {
            BusinessContext.DepartmentBusiness.Insert(department);
        }

        [HttpPut]
        [Route("")]
        [AuthorizationFilter(Role.Admin)]
        public void Update([FromBody]Department department)
        {
            BusinessContext.DepartmentBusiness.Update(department);
        }

        [HttpDelete]
        [Route("{departmentID:Guid}")]
        [AuthorizationFilter(Role.Admin)]
        public void Delete(Guid departmentID)
        {
            BusinessContext.DepartmentBusiness.Delete(departmentID);
        }

        #endregion     
    }
}


