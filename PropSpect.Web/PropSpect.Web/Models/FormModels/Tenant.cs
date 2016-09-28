using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PropSpect.Web.Controllers.Helpers.CustomWebViewPageEngine;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using PropSpect.Api.Models.Response;

namespace PropSpect.Web.Models.FormModels
{
    public class Tenant
    {
        public int TenantID { get; set; }
        public string Title { get; set; }
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public string PreferredName { get; set; }
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        [DisplayName("ID Number")]
        public string IDNumber { get; set; }
        [DisplayName("Tel Work")]
        public string TelWork { get; set; }
        [DisplayName("Tel Mobile")]
        public string TelMobile { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }

        [ListOptions(Hide = true)]
        [MinLength(13, ErrorMessage = "Not a valid ID Number")]
        [MaxLength(13, ErrorMessage = "Not a valid ID Number")]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Not a valid ID Number")]
        [Required]
        public int UserID { get; set; }
        //[EmailAddress]
        public string Username { get; set; }
        [ListOptions(Hide = true)]
        [EditOptions(Type = ControlType.Dropdown, SourceName = "RoleItems")]
        public string Type { get; set; }
        [ListOptions(Hide = true)]
        public string Password { get; set; }



        public static Tenant Create(TenantResponse response)
        {
            if (response == null)
                return null;

            Tenant tenant = new Tenant();
            tenant.TenantID = response.TenantID;
            tenant.Email = response.Email;
            tenant.FirstName = response.FirstName;
            tenant.IDNumber = response.IDNumber;
            tenant.LastName = response.LastName;
            tenant.PreferredName = response.PreferredName;
            tenant.SecondName = response.SecondName;
            tenant.TelMobile = response.TelMobile;
            tenant.TelWork = response.TelWork;
            tenant.ThirdName = response.ThirdName;
            tenant.Title = response.Title;
            tenant.Website = response.Website;

            return tenant;

        }


        public static List<Tenant> CreateList(List<TenantResponse> response)
        {
            if (response == null)
                return null;

            List<Tenant> tenants = new List<Tenant>();
            foreach (var tenant in response)
            {
                tenants.Add(Create(tenant));
            }
            return tenants;
        }

    }
}