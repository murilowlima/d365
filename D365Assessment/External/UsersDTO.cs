using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace D365Assessment.External
{
    [DataContract]
    public class UsersDTO
    {
        [DataMember(Name = "results")]
        public IList<RandomUserDTO> Users { get; set; }
    }
}
