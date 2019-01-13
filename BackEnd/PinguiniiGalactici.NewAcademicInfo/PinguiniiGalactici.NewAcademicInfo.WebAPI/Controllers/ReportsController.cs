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

namespace PinguiniiGalactici.NewAcademicInfo.WebAPI
{
    [AuthenticationFilter]
    [RoutePrefix("reports")]
    public class ReportsController: MainAPIController
    {
        [HttpGet]
        [Route("average/{CourseID:Guid}/{TypeID:Guid}")]
        [AuthorizationFilter(Role.Admin, Role.Teacher)]
        public IEnumerable<AverageGradeReport> AverageGradesReport(Guid CourseID, Guid TypeID)
        {
            return BusinessContext.ReportsBusiness.AverageGradesReport(CourseID, TypeID);
        }

        [HttpGet]
        [Route("passing-grades/{CourseID:Guid}/{TypeID:Guid}")]
        [AuthorizationFilter(Role.Admin, Role.Teacher)]
        public IEnumerable<PassingGradesReport> PassingGradesReport(Guid CourseID, Guid TypeID)
        {
            return BusinessContext.ReportsBusiness.PassingGradesReport(CourseID, TypeID);
        }

        [HttpGet]
        [Route("group-attendances/{CourseID:Guid}/{TypeID:Guid}/{GroupNumber:int}")]
        [AuthorizationFilter(Role.Admin, Role.Teacher)]
        public IEnumerable<GroupAttendacesReport> GroupAttendancesReport(Guid CourseID, Guid TypeID, Int32 GroupNumber)
        {
            return BusinessContext.ReportsBusiness.GroupAttendancesReport(CourseID, TypeID, GroupNumber);
        }

        [HttpGet]
        [Route("group-grades/{CourseID:Guid}/{TypeID:Guid}/{GroupNumber:int}")]
        [AuthorizationFilter(Role.Admin, Role.Teacher)]
        public IEnumerable<CompleteGroupGradesReport> GroupGradesReport(Guid CourseID, Guid TypeID, Int32 GroupNumber)
        {
            return BusinessContext.ReportsBusiness.GroupGradesReport(CourseID, TypeID, GroupNumber);
        }
    }
}