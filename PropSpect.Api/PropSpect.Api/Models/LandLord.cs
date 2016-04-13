using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PropSpect.Api.Models
{
    [Table("land_landlord_master")]
    public class Landlord
    {
        [Column("key_id")]
        public int LandlordID { get; set; }
        [Column("land_landlord_type")]
        public string Type { get; set; }
        [Column("land_landlord_name")]
        public string Name { get; set; }
        [Column("land_landlord_address_unit_nr")]
        public string AddressUnitNr { get; set; }
        [Column("land_landlord_address_complex_name")]
        public string ComplexName { get; set; }
        [Column("land_landlord_address_street_number")]
        public string StreetNumber { get; set; }
        [Column("land_landlord_address_street")]
        public string StreetName { get; set; }
        [Column("land_landlord_address_suburb")]
        public string Suburb { get; set; }
        [Column("land_landlord_address_city")]
        public string CityName { get; set; }
        [Column("land_landlord_address_code")]
        public int PostalCode { get; set; }
        [Column("land_landlord_tel_work")]
        public string TelWork { get; set; }
        [Column("land_landlord_tel_mobile")]
        public string TelMobile { get; set; }
        [Column("land_landlord_fax")]
        public string Fax { get; set; }
        [Column("land_landlord_email")]
        public string Email { get; set; }
        [Column("land_landlord_website")]
        public string Website { get; set; }
        [Column("land_landlord_title")]
        public string Title { get; set; }
        [Column("land_landlord_first_name")]
        public string FirstName { get; set; }
        [Column("land_landlord_second_nam")]
        public string SecondName { get; set; }
        [Column("land_landlord_third_name")]
        public string ThirdName { get; set; }
        [Column("land_landlord_last_name")]
        public string LastName { get; set; }
        [Column("land_landlord_id_number")]
        public string IDNumber { get; set; }
        [Column("land_landlord_reg_number")]
        public string RegNumber { get; set; }
        [Column("land_landlord_vat_number")]
        public string VatNumber { get; set; }
    }
}