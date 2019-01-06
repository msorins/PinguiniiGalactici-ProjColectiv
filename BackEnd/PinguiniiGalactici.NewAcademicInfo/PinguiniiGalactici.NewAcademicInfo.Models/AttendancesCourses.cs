using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PinguiniiGalactici.NewAcademicInfo.Models
{
    public class AttendancesCourses
    {
        [DataMember(Name = "AttendanceID")]
        public Guid AttendanceID { get; set; }
        [DataMember(Name = "EnrollmentID")]
        public Guid EnrollmentID { get; set; }
        [DataMember(Name = "WeekNr")]
        public Int32 WeekNr { get; set; }
        [DataMember(Name = "TypeID")]
        public Guid TypeID { get; set; }
        [DataMember(Name = "Grade")]
        public Nullable<decimal> Grade { get; set; }
        [DataMember(Name = "CourseID")]
        public Guid CourseID { get; set; }
        [DataMember(Name = "CourseName")]
        public string CourseName { get; set; }
        [DataMember(Name = "TotalLabNr")]
        public Int32 TotalLabNr { get; set; }
        [DataMember(Name = "TotalSeminarNr")]
        public Int32 TotalSeminarNr { get; set; }
        [DataMember(Name = "Year")]
        public Int32 Year { get; set; }
        [DataMember(Name = "TypeName")]
        public string TypeName { get; set; }
    }
}