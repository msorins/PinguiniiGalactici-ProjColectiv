using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PinguiniiGalactici.NewAcademicInfo.Models
{
    [DataContract(Name = "Table1")]
    public class Student
    {
        [DataMember(Name = "RegistrationNumber")]
        public Int32 RegistrationNumber { get; set; }
        [DataMember(Name = "Name")]
        public String Name { get; set; }
        [DataMember(Name = "Email")]
        public String Email { get; set; }
        [DataMember(Name = "GroupNumber")] 
        public String GroupNumber { get; set; }
        [DataMember(Name = "Username")]
        public String Username { get; set; }
    }
}
