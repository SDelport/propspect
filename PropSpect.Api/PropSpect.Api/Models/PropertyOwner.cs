using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PropSpect.Api.Models
{
    [Table("prop_property_owner")]
    public class PropertyOwner
    {
        [Column("key_id")]
        public int PropertyOwnerID { get; set; }
        [Column("parent_id")]
        public int PropertyID { get; set; }
        [Column("prop_owner_id")]
        public int OwnerID { get; set; }
        [Column("prop_owner_active")]
        public char OwnerActive { get; set; }
    }
}