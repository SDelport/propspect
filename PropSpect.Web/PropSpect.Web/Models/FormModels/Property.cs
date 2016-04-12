using PropSpect.Api.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PropSpect.Web.Controllers.Helpers.CustomWebViewPageEngine;
using System.Web.Mvc;

namespace PropSpect.Web.Models.FormModels
{
    public class Property
    {
        public int PropertyID { get; set; }
        public string PropertyType { get; set; }
        public string UnitNumber { get; set; }
        public string ComplexName { get; set; }
        public string StreetNumber { get; set; }
        public string StreetName { get; set; }
        public string Suburb { get; set; }
        [EditOptions(Type = ControlType.Dropdown, SourceName = "CityItems")]
        [ListOptions(SourceName = "CityItems")]
        public string City { get; set; }
        public int PostalCode { get; set; }



        public static Property Create(PropertyResponse response)
        {
            if (response == null)
                return null;

            Property property = new Property();
            property.PropertyID = response.PropertyID;
            property.StreetName = response.StreetName;
            property.StreetNumber = response.StreetNumber;
            property.City = response.City;
            property.ComplexName = response.ComplexName;
            property.PostalCode = response.PostalCode;
            property.PropertyID = response.PropertyID;
            property.PropertyType = response.PropertyType;
            property.UnitNumber = response.UnitNumber;

            return property;

        }

        public static List<Property> CreateList(List<PropertyResponse> response)
        {
            if (response == null)
                return null;

            List<Property> landlords = new List<Property>();
            foreach (var landlord in response)
            {
                landlords.Add(Create(landlord));
            }
            return landlords;
        }


    }
}