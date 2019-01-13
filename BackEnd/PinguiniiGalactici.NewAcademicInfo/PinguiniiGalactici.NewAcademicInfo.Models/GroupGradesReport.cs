using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PinguiniiGalactici.NewAcademicInfo.Models
{
    public class GroupGradesReport
    {
        [DataMember(Name = "Grade")]
        public Decimal Grade { get; set; }
    }
}
