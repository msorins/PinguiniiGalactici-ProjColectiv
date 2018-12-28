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
    [RoutePrefix("attendances")]
    public class AttendanceController : MainAPIController
    {
        //[Route("{userID:Guid}")] - example for Guid (Type must be specified)
        #region Methods
        [HttpGet]
        [Route("")]
        //[AuthorizationFilter(Role.Administrator)]
        public IEnumerable<Attendance> ReadAll()
        {
            return BusinessContext.AttendancesBusiness.ReadAll();
        }

        [HttpGet]
        [Route("{AttendancesNumber:Guid}")]
        public Attendance ReadById(Guid AttendancesNumber)
        {
            return BusinessContext.AttendancesBusiness.ReadById(AttendancesNumber);
        }

        [HttpPost]
        [Route("")]
        public void Insert([FromBody]Attendance Attendances)
        {
            BusinessContext.AttendancesBusiness.Insert(Attendances);
        }

        [HttpPut]
        [Route("")]
        public void Update([FromBody]Attendance Attendances)
        {
            BusinessContext.AttendancesBusiness.Update(Attendances);
        }

        [HttpDelete]
        [Route("{AttendancesNumber:Guid}")]
        public void Delete(Guid AttendancesNumber)
        {
            BusinessContext.AttendancesBusiness.Delete(AttendancesNumber);
        }
        #endregion
    }
}


