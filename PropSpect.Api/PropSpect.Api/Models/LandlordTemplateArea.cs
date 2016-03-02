using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PropSpect.Api.Models
{
    [Table("land_landlord_template_area")]
    public class LandlordTemplateArea
    {
        [Column("key_id")]
        public int LandlordTemplateAreaID { get; set; }

        [Column("comp_area_name")]
        public string AreaName { get; set; }

        [Column("comp_area_order")]
        public int AreaOrder { get; set; }
    }
}