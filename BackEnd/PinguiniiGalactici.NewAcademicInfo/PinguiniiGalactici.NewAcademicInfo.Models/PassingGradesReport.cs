using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PinguiniiGalactici.NewAcademicInfo.Models
{
    public class PassingGradesReport
    {
        [DataMember(Name = "GroupNumber")]
        public Int32 GroupNumber { get; set; }
        [DataMember(Name = "PassingGradesNumber")]
        public Int32 PassingGradesNumber { get; set; }
        [DataMember(Name = "TotalGradesNumber")]
        public Int32 TotalGradesNumber { get; set; }
    }
}
