using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropSpect.Api.Models.Request
{
    public class CreatePropertyTenantRequest
    {
        public int PropertyTenantID { get; set; }
        public int TenantID { get; set; }
    }
}
