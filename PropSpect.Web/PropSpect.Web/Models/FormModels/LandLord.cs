using PropSpect.Api.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PropSpect.Web.Controllers.Helpers.CustomWebViewPageEngine;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace PropSpect.Web.Models.FormModels
{
    public class Landlord
    {
        //Properties Used
        [ListOptions(Display = "Company Name")]
        [EditOptions(Display = "Company Name")]
        public string Name { get; set; }
        [ListOptions(Display = "Contact Name")]
        [EditOptions(Display = "Contact Name")]
        public string FirstName { get; set; }
        [ListOptions(Display = "Contact Surname")]
        [EditOptions(Display = "Contact Surname")]
        public string LastName { get; set; }
        [EmailAddress(ErrorMessage ="Please provide a valid email address")]
        public string Email { get; set; }
        public string Website { get; set; }
        [ListOptions(Display = "VAT Number")]
        [EditOptions(Display = "VAT Number")]
        public string VatNumber { get; set; }
        [ListOptions(Display = "Registration Number")]
        [EditOptions(Display = "Registration Number")]
        public string RegNumber { get; set; }
        [ListOptions(Display = "Work Number")]
        [EditOptions(Display = "Work Number")]
        public string TelWork { get; set; }
        [ListOptions(Display = "Cell Number")]
        [EditOptions(Display = "Cell Number")]
        public string TelMobile { get; set; }



        //Properties Not Used
        [ListOptions(Hide = true)]
        [EditOptions(Type = ControlType.Hidden)]
        public int LandlordID { get; set; }
        [ListOptions(Hide = true)]
        [EditOptions(Type = ControlType.Hidden)]
        public string Type { get; set; }  
        [ListOptions(Hide = true)]
        [EditOptions(Type = ControlType.Hidden)]
        public string AddressUnitNr { get; set; }
        [ListOptions(Hide = true)]
        [EditOptions(Type = ControlType.Hidden)]
        public string ComplexName { get; set; }
        [ListOptions(Hide = true)]
        [EditOptions(Type = ControlType.Hidden)]
        public string StreetNumber { get; set; }
        [ListOptions(Hide = true)]
        [EditOptions(Type = ControlType.Hidden)]
        public string StreetName { get; set; }
        [ListOptions(Hide = true)]
        [EditOptions(Type = ControlType.Hidden)]
        public string Suburb { get; set; }
        //[EditOptions(Type = ControlType.Dropdown, SourceName = "CityItems")]
        //[ListOptions(SourceName = "CityItems")]
        [ListOptions(Hide = true)]
        [EditOptions(Type = ControlType.Hidden)]
        public string CityName { get; set; }
        //[EditOptions(Type = ControlType.Number)]
        //[ListOptions(Hide = true)]
        [ListOptions(Hide = true)]
        [EditOptions(Type = ControlType.Hidden)]
        public int PostalCode { get; set; }
        [ListOptions(Hide = true)]
        [EditOptions(Type = ControlType.Hidden)]
        public string Fax { get; set; }
        [ListOptions(Hide = true)]
        [EditOptions(Type = ControlType.Hidden)]
        public string Title { get; set; }
        [ListOptions(Hide = true)]
        [EditOptions(Type = ControlType.Hidden)]
        public string SecondName { get; set; }
        [ListOptions(Hide = true)]
        [EditOptions(Type = ControlType.Hidden)]
        public string ThirdName { get; set; }
        [ListOptions(Hide = true)]
        [EditOptions(Type = ControlType.Hidden)]
        public string IDNumber { get; set; }

       

        public static Landlord Create(LandlordResponse response)
        {
            if (response == null)
                return null;

            Landlord landlord = new Landlord();
            landlord.LandlordID = response.LandlordID;
            landlord.Type = response.Type;
            landlord.Name = response.Name;
            landlord.AddressUnitNr = response.AddressUnitNr;
            landlord.ComplexName = response.ComplexName;
            landlord.StreetNumber = response.StreetNumber;
            landlord.StreetName = response.StreetName;
            landlord.Suburb = response.Suburb;
            landlord.CityName = response.CityName;
            landlord.PostalCode = response.PostalCode;
            landlord.TelWork = response.TelWork;
            landlord.TelMobile = response.TelMobile;
            landlord.Fax = response.Fax;
            landlord.Email = response.Email;
            landlord.Website = response.Website;
            landlord.Title = response.Title;
            landlord.FirstName = response.FirstName;
            landlord.SecondName = response.SecondName;
            landlord.ThirdName = response.ThirdName;
            landlord.LastName = response.LastName;
            landlord.IDNumber = response.IDNumber;
            landlord.RegNumber = response.RegNumber;
            landlord.VatNumber = response.VatNumber;
            return landlord;

        }

        public static List<Landlord> CreateList(List<LandlordResponse> response)
        {
            if (response == null)
                return null;

            List<Landlord> landlords = new List<Landlord>();
            foreach (var landlord in response)
            {
                landlords.Add(Create(landlord));
            }
            return landlords;
        }


    }
}