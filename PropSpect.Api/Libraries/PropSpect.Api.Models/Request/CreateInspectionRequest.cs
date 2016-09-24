using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropSpect.Api.Models.Request
{
    public class CreateInspectionRequest
    {
        public int PropertyID { get; set; }
        public int TenantID { get; set; }
        public int OwnerID { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
        

    }
}
