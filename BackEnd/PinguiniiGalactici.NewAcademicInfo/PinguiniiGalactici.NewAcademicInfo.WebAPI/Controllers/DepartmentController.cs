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
    [RoutePrefix("departments")]
    public class DepartmentController : MainAPIController
    {
        #region Methods     
        [HttpGet]
        [Route("")]
        //[AuthorizationFilter(Role.Administrator)]
        public IEnumerable<Department> ReadAll()
        {
            return BusinessContext.DepartmentBusiness.ReadAll();
        }

        [HttpGet]
        [Route("{departmentID:Guid}")]
        public Department ReadById(Guid departmentID)
        {
            return BusinessContext.DepartmentBusiness.ReadById(departmentID);
        }

        [HttpPost]
        [Route("")]
        public void Insert([FromBody]Department department)
        {
            BusinessContext.DepartmentBusiness.Insert(department);
        }

        [HttpPut]
        [Route("")]
        public void Update([FromBody]Department department)
        {
            BusinessContext.DepartmentBusiness.Update(department);
        }

        [HttpDelete]
        [Route("{departmentID:Guid}")]
        public void Delete(Guid departmentID)
        {
            BusinessContext.DepartmentBusiness.Delete(departmentID);
        }

        #endregion     
    }
}


