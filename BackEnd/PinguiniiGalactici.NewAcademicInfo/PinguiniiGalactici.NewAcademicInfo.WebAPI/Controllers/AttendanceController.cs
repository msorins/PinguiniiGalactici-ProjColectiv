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
    [RoutePrefix("attendances")]
    public class AttendanceController : MainAPIController
    {
        #region Methods
        [HttpGet]
        [Route("")]
        [AuthorizationFilter(Role.Teacher)]
        public IEnumerable<Attendance> ReadAll()
        {
            return BusinessContext.AttendancesBusiness.ReadAll();
        }

        [HttpGet]
        [Route("{AttendancesNumber:Guid}")]
        [AuthorizationFilter(Role.Teacher)]
        public Attendance ReadById(Guid AttendancesNumber)
        {
            return BusinessContext.AttendancesBusiness.ReadById(AttendancesNumber);
        }

        [HttpPost]
        [Route("")]
        [AuthorizationFilter(Role.Teacher)]
        public void Insert([FromBody]Attendance Attendances)
        {
            BusinessContext.AttendancesBusiness.Insert(Attendances);
        }

        [HttpPut]
        [Route("")]
        [AuthorizationFilter(Role.Teacher)]
        public void Update([FromBody]Attendance Attendances)
        {
            BusinessContext.AttendancesBusiness.Update(Attendances);
        }

        [HttpDelete]
        [Route("{AttendancesNumber:Guid}")]
        [AuthorizationFilter(Role.Teacher)]
        public void Delete(Guid AttendancesNumber)
        {
            BusinessContext.AttendancesBusiness.Delete(AttendancesNumber);
        }
        #endregion
    }
}


