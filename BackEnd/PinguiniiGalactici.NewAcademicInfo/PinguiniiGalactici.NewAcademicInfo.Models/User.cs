using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PinguiniiGalactici.NewAcademicInfo.Models.Enumerations;

namespace PinguiniiGalactici.NewAcademicInfo.Models
{
    [DataContract]
    public class User
    {
        [DataMember(Name = "Username")]
        public string Username { get; set; }
        [DataMember(Name = "Password")]
        public string Password { get; set; }
        [DataMember(Name = "Role")]
        public Role Role { get; set; }
    }
}
