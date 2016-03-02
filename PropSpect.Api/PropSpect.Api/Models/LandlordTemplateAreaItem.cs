using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PropSpect.Api.Models
{
    [Table("land_landlord_template_area_item")]
    public class LandlordTemplateAreaItem
    {
        [Column("key_id")]
        public int LandlordTemplateAreaItemID { get; set; }

        [Column("land_item_name")]
        public string ItemName { get; set; }

        [Column("land_item_order")]
        public int ItemOrder { get; set; }
    }
}