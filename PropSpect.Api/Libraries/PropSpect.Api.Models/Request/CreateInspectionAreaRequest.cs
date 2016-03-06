using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropSpect.Api.Models.Request
{
    public class CreateInspectionAreaRequest
    {
        public int InspectionAreaID { get; set; }
        public int AreaID { get; set; }
    }
}
