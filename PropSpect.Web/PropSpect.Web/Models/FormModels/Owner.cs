using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PropSpect.Web.Controllers.Helpers.CustomWebViewPageEngine;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace PropSpect.Web.Models.FormModels
{
    public class Owner
    {
        public int    OwnerID { get; set; }
        public string OwnerType { get; set; }
        [DisplayName("First Name")]
        public string Name { get; set; }
        public string UnitNr { get; set; }
        public string ComplexName { get; set; }
        public string StreetNumber { get; set; }
        public string StreetName { get; set; }
        public string Suburb { get; set; }
        public string City { get; set; }
        public int    PostalCode { get; set; }
        [DisplayName("Tel Work")]
        public string TelWork { get; set; }
        [DisplayName("Tel Mobile")]
        public string TelMobile { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        [DisplayName("ID Number")]
        public string IDNumber { get; set; }

        [ListOptions(Hide = true)]
        public int    UserID { get; set; }
        public string Username { get; set; }
        [ListOptions(Hide = true)]
        [EditOptions(Type = ControlType.Dropdown, SourceName = "RoleItems")]
        public string Type { get; set; }
        [ListOptions(Hide = true)]
        public string Password { get; set; }
    }
}