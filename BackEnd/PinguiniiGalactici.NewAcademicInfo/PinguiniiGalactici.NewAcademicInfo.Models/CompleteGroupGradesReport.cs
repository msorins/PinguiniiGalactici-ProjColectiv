using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PinguiniiGalactici.NewAcademicInfo.Models
{
    public class CompleteGroupGradesReport
    {
        [DataMember(Name = "RoundValue")]
        public Int32 RoundValue { get; set; }
        [DataMember(Name = "GradesCount")]
        public Int32 GradesCount { get; set; }
    }
}
