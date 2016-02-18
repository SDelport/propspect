using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PropSpect.Api.Models
{
    [Table("ten_tenant_master")]
    public class Tenant
    {
        [Column("key_id")]
        public int TenantID { get; set; }
        [Column("ten_tenant_title")]
        public string Title { get; set; }
        [Column("ten_tenant_first_name")]
        public string FirstName { get; set; }
        [Column("ten_tenant_second_name")]
        public string SecondName { get; set; }
        [Column("ten_tenant_third_name")]
        public string ThirdName { get; set; }
        [Column("ten_tenant_preferred_name")]
        public string PreferredName { get; set; }
        [Column("ten_tenant_last_name")]
        public string LastName { get; set; }
        [Column("ten_tenant_id_number")]
        public string IDNumber { get; set; }
        [Column("ten_tenant_tel_work")]
        public string TelWork { get; set; }
        [Column("ten_tenant_tel_mobile")]
        public string TelMobile { get; set; }
        [Column("ten_tenant_email")]
        public string Email { get; set; }
        [Column("ten_tenant_website")]
        public string Website { get; set; }

    }
}