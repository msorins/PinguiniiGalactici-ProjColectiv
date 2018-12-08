using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PinguiniiGalactici.NewAcademicInfo.Models
{
    [DataContract(Name = "Table3")]
    public class Course
    {
        [DataMember(Name = "CourseID")]
        public Guid CourseID { get; set; }
        [DataMember(Name = "Name")]
        public String Name { get; set; }
        [DataMember(Name = "DepartmentID")]
        public Guid DepartmentID { get; set; }
        [DataMember(Name = "Year")]
        public Int32 Year { get; set; }
        [DataMember(Name = "TotalLabNr")]
        public Int32 TotalLabNr  { get; set; }
        [DataMember(Name = "TotalSeminarNr")]
        public Int32 TotalSeminarNr { get; set; }
    }
}
