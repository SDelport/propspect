using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropSpect.Api.Models.Response
{
    public class InspectionAreaItemResponse
    {
        public int InspectionAreaID { get; set; }
        public int InspectionAreaItemID { get; set; }
        public int ItemID { get; set; } 
        public string ItemDescription { get; set; }
        public string ItemCondition { get; set; }
        public string ItemRepair { get; set; }

    }
}
