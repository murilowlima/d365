using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace D365Assessment.External
{
    [DataContract]
    public class NameDTO
    {
        [DataMember(Name = "title")]
        public string Title { get; set; }
        [DataMember(Name = "first")]
        public string First { get; set; }
        [DataMember(Name = "last")]
        public string Last { get; set; }
    }

}
