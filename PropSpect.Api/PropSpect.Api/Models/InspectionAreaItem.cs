using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PropSpect.Api.Models
{
    [Table("prop_property_inspection_area_item")]
    public class InspectionAreaItem
    {
        [Column("key_id")]
        public int InspectionAreaItemID { get; set; }

        [Column("prop_item_id")]
        public int ItemID { get; set; }

        [Column("prop_item_description")]
        public string ItemDescription { get; set; }

        [Column("prop_item_condition")]
        public string ItemCondition { get; set; }

        [Column("prop_item_repair")]
        public string ItemRepair { get; set; }
        
    }
}