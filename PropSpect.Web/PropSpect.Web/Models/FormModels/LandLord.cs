using PropSpect.Api.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PropSpect.Web.Controllers.Helpers.CustomWebViewPageEngine;
using System.Web.Mvc;

namespace PropSpect.Web.Models.FormModels
{
    public class LandLord
    {
        [ListOptions(Hide = true)]
        [EditOptions(Type = ControlType.Hidden)]
        public int LandlordID { get; set; }   
        public string Type { get; set; }
        public string Name { get; set; }
        [ListOptions(Hide = true)]
        public string AddressUnitNr { get; set; }
        [ListOptions(Hide = true)]
        public string ComplexName { get; set; }
        [ListOptions(Hide = true)]
        public string StreetNumber { get; set; }
        [ListOptions(Hide = true)]
        public string StreetName { get; set; }
        [ListOptions(Hide = true)]
        public string Suburb { get; set; }
        [EditOptions(Type = ControlType.Dropdown, SourceName = "CityItems")]
        [ListOptions(SourceName = "CityItems")]
        public string CityName { get; set; }
        [EditOptions(Type = ControlType.Number)]
        [ListOptions(Hide = true)]
        public int PostalCode { get; set; }
        public string TelWork { get; set; }
        public string TelMobile { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        [ListOptions(Hide = true)]
        public string Website { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        [ListOptions(Hide = true)]
        public string ThirdName { get; set; }
        public string LastName { get; set; }
        [ListOptions(Hide = true)]
        public string IDNumber { get; set; }

       

        public static LandLord Create(LandlordResponse response)
        {
            if (response == null)
                return null;

            LandLord landlord = new LandLord();
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

            return landlord;

        }

        public static List<LandLord> CreateList(List<LandlordResponse> response)
        {
            if (response == null)
                return null;

            List<LandLord> landlords = new List<LandLord>();
            foreach (var landlord in response)
            {
                landlords.Add(Create(landlord));
            }
            return landlords;
        }


    }
}