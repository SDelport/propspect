using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PropSpect.Api.Models
{
    [Table("land_landlord_admin")]
    public class LandlordAdmin
    {
        [Column("key_id")]
        public int LandlordAdminID { get; set; }
        [Column("land_admin_first_name")]
        public string FirstName { get; set; }
        [Column("land_admin_preferred_name")]
        public string PreferredName { get; set; }
        [Column("land_admin_last_name")]
        public string LastName { get; set; }
        [Column("land_admin_id_number")]
        public string IDNumber { get; set; }
        [Column("land_admin_tel")]
        public string TelWork { get; set; }
        [Column("land_admin_mobile")]
        public string TelMobile { get; set; }
        [Column("land_admin_email")]
        public string Email { get; set; }
        [Column("land_admin_user_id")]
        public int UserKey { get; set; }

    }
}