using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PropSpect.Web.Models.FormModels
{
    public class InspectionAreaItem
    {
        public int InspectionAreaItemID { get; set; }

        public int InspectionAreaID { get; set; }
        public int ItemID { get; set; }

        public string ItemDescription { get; set; }

        public string ItemCondition { get; set; }

        public string ItemRepair { get; set; }
    }
}