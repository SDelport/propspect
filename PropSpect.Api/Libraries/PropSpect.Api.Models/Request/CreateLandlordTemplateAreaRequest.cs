using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropSpect.Api.Models.Request
{
    public class CreateLandlordTemplateAreaRequest
    {
        public int LandlordTemplateAreaID { get; set; }
        public string AreaName { get; set; }
        public int AreaOrder { get; set; }
    }
}
