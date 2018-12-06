using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PinguiniiGalactici.NewAcademicInfo.Models
{
    [DataContract]
    public class Faculty
    {
        [DataMember(Name ="Idk")]
        public string Idk { get; set; }

        [DataMember(Name = "Idk2")]
        public int Idk2 { get; set; }
    }
}
