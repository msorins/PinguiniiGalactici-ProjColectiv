using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PinguiniiGalactici.NewAcademicInfo.Models
{
    [DataContract(Name = "Table1Table3")]
    public class StudentCourse
    {
        [DataMember(Name = "EnrollmentID")]
        public Guid EnrollmentID { get; set; }
        [DataMember(Name = "StudentID")]
        public Int32 StudentID { get; set; }
        [DataMember(Name = "CourseID")]
        public Guid CourseID { get; set; }

    }
}
