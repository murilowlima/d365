using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace D365Assessment.External
{
    [DataContract]
    public class StreetDTO
    {
        [DataMember(Name = "number")]
        public string Number { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }
    }
}
