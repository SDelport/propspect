using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PropSpect.Api.Models
{
    [Table("prop_property_inspection")]
    public class Inspection
    {
        [Column("key_id")]
        public int InspectionID { get; set; }
        [Column("parent_id")]
        public int PropertyID { get; set; }
        [Column("prop_inspection_type")]
        public string Type { get; set; }
        [Column("prop_inspection_date")]
        public string Date { get; set; }
        [Column("prop_inspection_entity_type")]
        public string EntityType { get; set; }
        [Column("prop_inspection_entity_id")]
        public int? EntityID { get; set; }
        [Column("prop_inspection_house_clean")]
        public string HouseClean { get; set; }
        [Column("prop_inspection_house_comments")]
        public string HouseComments { get; set; }
        [Column("prop_inspection_carpets_clean")]
        public string CarpetsClean { get; set; }
        [Column("prop_inspection_carpets_comments")]
        public string CarpetsComments { get; set; }
        [Column("prop_inspection_garden_clean")]
        public string GardenClean { get; set; }
        [Column("prop_inspection_garden_comments")]
        public string GardenComments { get; set; }
        [Column("prop_inspection_pool_clean")]
        public string PoolClean { get; set; }
        [Column("prop_inspection_pool_comments")]
        public string PoolComments { get; set; }
        [Column("prop_inspection_overall_comments")]
        public string OverallComments { get; set; }
        [Column("prop_inspection_completed")]
        public Boolean Completed { get; set; }
    }
}