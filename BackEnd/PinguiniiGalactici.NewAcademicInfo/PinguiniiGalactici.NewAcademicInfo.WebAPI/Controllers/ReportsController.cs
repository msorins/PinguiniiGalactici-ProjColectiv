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
        [Route("average/{CourseID:Guid}/{TypeName}")]  // TypeName should be 'Laborator' or 'Seminar'
        [AuthorizationFilter(Role.Admin, Role.Teacher)]
        public IEnumerable<AverageGradeReport> AverageGradesReport(Guid CourseID, String TypeName)
        {
            return BusinessContext.ReportsBusiness.AverageGradesReport(CourseID, TypeName);
        }

        [HttpGet]
        [Route("passing-grades/{CourseID:Guid}/{TypeName}")]  // TypeName should be 'Laborator' or 'Seminar'
        [AuthorizationFilter(Role.Admin, Role.Teacher)]
        public IEnumerable<PassingGradesReport> PassingGradesReport(Guid CourseID, String TypeName)
        {
            return BusinessContext.ReportsBusiness.PassingGradesReport(CourseID, TypeName);
        }
    }
}