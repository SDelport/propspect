using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PropSpect.Api.Models
{
    [Table("own_owner_master")]
    public class Owner
    {
        [Column("key_id")]
        public int OwnerID { get; set; }
        [Column("parent_id")]
        public int ParentIDRENAME { get; set; }
        [Column("own_owner_type")]
        public string Type { get; set; }
        [Column("own_owner_name")]
        public string Name { get; set; }
        [Column("own_owner_address_unit_nr")]
        public string UnitNr { get; set; }
        [Column("own_owner_address_complex_name")]
        public string ComplexName { get; set; }
        [Column("own_owner_address_street_number")]
        public string StreetNumber { get; set; }
        [Column("own_owner_address_street")]
        public string StreetName { get; set; }
        [Column("own_owner_address_suburb")]
        public string Suburb { get; set; }
        [Column("own_owner_address_city")]
        public string City { get; set; }
        [Column("own_owner_address_code")]
        public int PostalCode { get; set; }
        [Column("own_owner_tel_work")]
        public string TelWork { get; set; }
        [Column("own_owner_tel_mobile")]
        public string TelMobile { get; set; }
        [Column("own_owner_fax")]
        public string Fax { get; set; }
        [Column("own_owner_email")]
        public string Email { get; set; }
        [Column("own_owner_website")]
        public string Website { get; set; }
        [Column("own_owner_title")]
        public string Title { get; set; }
        [Column("own_owner_first_name")]
        public string FirstName { get; set; }
        [Column("own_owner_second_nam")]
        public string SecondName { get; set; }
        [Column("own_owner_third_name")]
        public string ThirdName { get; set; }
        [Column("own_owner_last_name")]
        public string LastName { get; set; }
        [Column("own_owner_id_number")]
        public string IDNumber { get; set; }
    }
}