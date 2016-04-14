using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PropSpect.Api.Models
{
    [Table("prop_property_tenant")]
    public class PropertyTenant
    {
        [Column("key_id")]
        public int PropertyTenantID { get; set; }
        [Column("parent_id")]
        public int PropertyID { get; set; }
        [Column("prop_tenant_id")]
        public int TenantID { get; set; }

    }
}