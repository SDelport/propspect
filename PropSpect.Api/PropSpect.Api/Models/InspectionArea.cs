using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PropSpect.Api.Models
{
    [Table("prop_property_inspection_area")]
    public class InspectionArea
    {
        [Column("key_id")]
        public int InspectionAreaID { get; set; }
        [Column("parent_id")]
        public int InspectionID { get; set; }
        [Column("prop_area_id")]
        public int AreaID { get; set; }

    }
}