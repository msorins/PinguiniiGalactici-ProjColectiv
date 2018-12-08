using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PinguiniiGalactici.NewAcademicInfo.Models
{
    [DataContract(Name = "Table5")]
    public class Group
    {
        [DataMember(Name = "GroupNumber")]
        public Int32 GroupNumber { get; set; }
        [DataMember(Name = "DepartmentID")]
        public Guid DepartmentID { get; set; }
    }
}
