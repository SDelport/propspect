using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PropSpect.Api.Models
{
    [Table("land_landlord_template")]
    public class LandlordTemplate
    {
        [Column("key_id")]
        public int LandlordTemplateID { get; set; }

        [Column("land_template_name")]
        public string TemplateName { get; set; }       
    }
}