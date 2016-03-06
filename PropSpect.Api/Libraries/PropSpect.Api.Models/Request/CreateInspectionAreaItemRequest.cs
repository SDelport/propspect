using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropSpect.Api.Models.Request
{
    public class CreateInspectionAreaItemRequest
    {
        public int InspectionAreaItemID { get; set; }
        public int ItemID { get; set; }
        public string ItemDescription { get; set; }
        public string ItemCondition { get; set; }
        public string ItemRepair { get; set; }
    }
}
