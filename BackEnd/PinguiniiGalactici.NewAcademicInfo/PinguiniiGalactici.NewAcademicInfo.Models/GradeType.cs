using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PinguiniiGalactici.NewAcademicInfo.Models
{
    [DataContract(Name = "Table7")]
    public class GradeType
    {
        [DataMember(Name = "TypeID")]
        public Guid TypeID { get; set; }
        [DataMember(Name = "Name")]
        public String Name { get; set; }
    }
}
