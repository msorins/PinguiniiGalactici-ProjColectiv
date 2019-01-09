using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PinguiniiGalactici.NewAcademicInfo.Models
{
    [DataContract(Name = "Table4")]
    public class Attendance
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
    }
}
