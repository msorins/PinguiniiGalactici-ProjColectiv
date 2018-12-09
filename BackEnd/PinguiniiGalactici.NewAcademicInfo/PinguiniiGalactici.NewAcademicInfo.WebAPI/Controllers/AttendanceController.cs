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

    [RoutePrefix("attendances")]
    public class AttendanceController : MainAPIController
    {
        //[Route("{userID:Guid}")] - example for Guid (Type must be specified)
        #region Methods
        [AuthenticationFilter]
        [HttpGet]
        [Route("")]
        //[AuthorizationFilter(Role.Administrator)]
        public IEnumerable<Attendance> ReadAll()
        {
            return BusinessContext.AttendancesBusiness.ReadAll();
        }

        [AuthenticationFilter]
        [HttpGet]
        [Route("{AttendancesNumber:Guid}")]
        public Attendance ReadById(Guid AttendancesNumber)
        {
            return BusinessContext.AttendancesBusiness.ReadById(AttendancesNumber);
        }

        [AuthenticationFilter]
        [HttpPost]
        [Route("")]
        public void Insert([FromBody]Attendance Attendances)
        {
            BusinessContext.AttendancesBusiness.Insert(Attendances);
        }

        [AuthenticationFilter]
        [HttpPut]
        [Route("")]
        public void Update([FromBody]Attendance Attendances)
        {
            BusinessContext.AttendancesBusiness.Update(Attendances);
        }

        [AuthenticationFilter]
        [HttpDelete]
        [Route("{AttendancesNumber:Guid}")]
        public void Delete(Guid AttendancesNumber)
        {
            BusinessContext.AttendancesBusiness.Delete(AttendancesNumber);
        }

        #endregion


    }
}


