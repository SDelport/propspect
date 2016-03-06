using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropSpect.Api.Models.Request
{
    public class CreateEntityRequest
    {
        public int PropertyEntityID { get; set; }
        public string EntityType { get; set; }
        public int EntityID { get; set; }
    }
}
