using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PinguiniiGalactici.NewAcademicInfo.Models
{
    public class GroupAttendacesReport
    {
        [DataMember(Name = "WeekNr")]
        public Int32 WeekNr { get; set; }
        [DataMember(Name = "AttendancesCount")]
        public Int32 AttendancesCount { get; set; }
    }
}
