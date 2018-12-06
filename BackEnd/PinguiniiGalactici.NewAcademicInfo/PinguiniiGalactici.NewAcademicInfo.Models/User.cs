using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PinguiniiGalactici.NewAcademicInfo.Models
{
    [DataContract]
    public class User
    {
        [DataMember(Name = "Username")]
        public string Username { get; set; }
    }
}
