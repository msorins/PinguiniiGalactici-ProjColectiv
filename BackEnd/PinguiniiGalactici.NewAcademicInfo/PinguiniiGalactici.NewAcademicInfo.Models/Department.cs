using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PinguiniiGalactici.NewAcademicInfo.Models
{
    [DataContract(Name = "Table6")]
    public class Department
    {
        [DataMember(Name = "DepartmentID")]
        public Guid DepartmentID { get; set; }
        [DataMember(Name = "Name")]
        public string Name { get; set; }
        [DataMember(Name = "FacultyID")]
        public Guid FacultyID { get; set; }
    }
}
