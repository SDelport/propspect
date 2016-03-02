using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PropSpect.Web.Models.FormModels.Property
{
    public class AddPropertyFormModel
    {
        public int PropertyID { get; set; }
        public string PropertyType { get; set; }
        public string UnitNumber { get; set; }
        public string ComplexName { get; set; }
        public string StreetNumber { get; set; }
        public string StreetName { get; set; }
        public string Suburb { get; set; }
        public string City { get; set; }
        public int PostalCode { get; set; }
    }
}