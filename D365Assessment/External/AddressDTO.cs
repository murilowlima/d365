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
    public class AddressDTO
    {
        [DataMember(Name = "street")]
        public StreetDTO Street { get; set; }

        [DataMember(Name = "city")]
        public string City { get; set; }
    }
}
