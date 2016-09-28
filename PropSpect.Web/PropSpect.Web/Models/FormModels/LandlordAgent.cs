using PropSpect.Web.Controllers.Helpers.CustomWebViewPageEngine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PropSpect.Web.Models.FormModels
{
    public class LandlordAgent
    {
        public int LandlordAgentID { get; set; }
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        public string PreferredName { get; set; }
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        [DisplayName("ID Number")]
        [MinLength(13,ErrorMessage ="Not a valid ID Number")]
        [MaxLength(13,ErrorMessage = "Not a valid ID Number")]
        [RegularExpression(@"^[0-9]+$", ErrorMessage ="Not a valid ID Number")]
        [Required]
        public string IDNumber { get; set; }
        [DisplayName("Work Number")]
        public string TelWork { get; set; }
        [DisplayName("Cell Number")]
        public string TelMobile { get; set; }
        public string Email { get; set; }
        public int UserKey { get; set; }

        [ListOptions(Hide = true)]
        public int UserID { get; set; }
        //[EmailAddress]
        public string Username { get; set; }
        [ListOptions(Hide = true)]
        [EditOptions(Type = ControlType.Dropdown, SourceName = "RoleItems")]
        public string Type { get; set; }
        [ListOptions(Hide = true)]
        public string Password { get; set; }
    }
}