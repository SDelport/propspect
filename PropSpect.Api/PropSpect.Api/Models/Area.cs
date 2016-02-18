using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PropSpect.Api.Models
{
    [Table("prop_property_area")]
    public class Area
    {
        [Column("key_id")]
        public int AreaID { get; set; }
        [Column("prop_area_name")]
        public string Name { get; set; }

    }
}