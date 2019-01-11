using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PinguiniiGalactici.NewAcademicInfo.Models
{
    public class AverageGradeReport
    {
        [DataMember(Name = "GroupNumber")]
        public Int32 GroupNumber { get; set; }
        [DataMember(Name = "AverageGrade")]
        public decimal AverageGrade { get; set; }

    }
}
