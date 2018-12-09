using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PinguiniiGalactici.NewAcademicInfo.Models
{
    [DataContract(Name = "Table2")]
    public class Teacher
    {
        [DataMember(Name = "TeacherID")]
        public Guid TeacherID { get; set; }
        [DataMember(Name = "Name")]
        public String Name { get; set; }
    }
}
