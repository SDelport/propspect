using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PropSpect.Api.Models
{
    [Table("land_landlord_agent")]
    public class LandlordAgent
    {
        [Column("key_id")]
        public int LandlordAgentID { get; set; }
        [Column("land_agent_first_name")]
        public string FirstName { get; set; }
        [Column("land_agent_preferred_name")]
        public string PreferredName { get; set; }
        [Column("land_agent_last_name")]
        public string LastName { get; set; }
        [Column("land_agent_id_number")]
        public string IDNumber { get; set; }
        [Column("land_agent_tel")]
        public string TelWork { get; set; }
        [Column("land_agent_mobile")]
        public string TelMobile { get; set; }
        [Column("land_agent_email")]
        public string Email { get; set; }
        [Column("land_agent_user_id")]
        public int UserKey { get; set; }

    }
}