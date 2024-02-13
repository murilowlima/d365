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
    public class RandomUserDTO
    {
        [DataMember(Name = "name")]
        public NameDTO Name { get; set; }

        [DataMember(Name = "phone")]
        public string Phone { get; set; }

        [DataMember(Name = "email")]
        public string Email { get; set; }

        [DataMember(Name = "location")]
        public AddressDTO Address { get; set; }
    }
}
