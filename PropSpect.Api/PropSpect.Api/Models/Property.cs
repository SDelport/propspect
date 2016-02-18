using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PropSpect.Api.Models
{
    [Table("prop_property_master")]
    public class Property
    {
        [Column("key_id")]
        public int PropertyID { get; set; }

        [Column("prop_property_type")]
        public string PropertyType { get; set; }
        [Column("prop_property_address_unit_nr")]
        public string UnitNumber { get; set; }
        [Column("prop_property_address_complex_name")]
        public string ComplexName { get; set; }
        [Column("prop_property_address_street_number")]
        public string StreetNumber { get; set; }
        [Column("prop_property_address_street")]
        public string StreetName { get; set; }
        [Column("prop_property_address_suburb")]
        public int Suburb { get; set; }
        [Column("prop_property_address_city")]
        public string City { get; set; }
        [Column("prop_property_address_code")]
        public int PostalCode { get; set; }

    }
}