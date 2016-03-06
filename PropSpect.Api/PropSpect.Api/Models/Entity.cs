using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PropSpect.Api.Models
{
    [Table("prop_property_entity")]
    public class Entity
    {
        [Column("key_id")]
        public int PropertyEntityID { get; set; }

        [Column("prop_entity_type")]
        public string EntityType { get; set; }

        [Column("prop_entity_id")]
        public int EntityID { get; set; }
    }
}