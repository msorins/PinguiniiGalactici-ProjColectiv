using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;
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
        [Route("forStudent")]
        [AuthorizationFilter(Role.Student)]
        public IEnumerable<Attendance> ReadForStudent()
        {
            return BusinessContext.AttendancesBusiness.ReadForStudent();
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

        [HttpPut]
        [Route("UpdateBulk")]
        [AuthorizationFilter(Role.Teacher)]
        public void UpdateBulk([FromBody]List<Attendance> Attendances)
        {
            BusinessContext.AttendancesBusiness.UpdateBulk(Attendances);
        }

        [HttpGet]
        [Route("WithCourses")]
        [AuthorizationFilter(Role.Teacher)]
        public IEnumerable<AttendancesCourses> ReadAllWithCourses()
        {
            return BusinessContext.AttendancesBusiness.ReadAllWithCourses();
        }

        [HttpGet]
        [Route("WithCourseAndStudent/{CourseID:Guid}/{RegistrationNumber:int}")]
        [AuthorizationFilter(Role.Teacher)]
        public IEnumerable<AttendancesCourses> ReadAllWithCourseAndStudent(Guid CourseID, int RegistrationNumber)
        {
            return BusinessContext.AttendancesBusiness.ReadAllWithCourseAndStudent(CourseID, RegistrationNumber);
        }

        [HttpPut]
        [Route("UpdateOrInsert")]
        [AuthorizationFilter(Role.Teacher)]
        public void UpdateOrInsert([FromBody] JObject data)
        {
            int studentID = int.Parse(GetRequiredParameterFromBody(data, "StudentID").ToString());
            Guid courseID = new Guid(GetRequiredParameterFromBody(data, "CourseID").ToString());
            int weekNr = int.Parse(GetRequiredParameterFromBody(data, "WeekNr").ToString());
            Guid typeID = new Guid(GetRequiredParameterFromBody(data, "TypeID").ToString());
            JToken JTokenGrade;
            decimal? grade = null;

            data.TryGetValue("Grade", out JTokenGrade);
            if (JTokenGrade != null)
                grade = decimal.Parse(JTokenGrade.ToString());

            BusinessContext.AttendancesBusiness.UpdateOrInsert(studentID, courseID, weekNr, typeID, grade);
        }

        private JToken GetRequiredParameterFromBody(JObject data, string property)
        {
            JToken result;
            data.TryGetValue(property, out result);
            if (result != null)
                return result;
            else
                throw new Exception(String.Format("Missing parameter - {0}", property));
        }
        #endregion
    }
}


