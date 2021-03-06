﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropSpect.Api.Models.Response
{
    public class OwnerResponse
    {
        public int OwnerID { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public string UnitNr { get; set; }
        public string ComplexName { get; set; }
        public string StreetNumber { get; set; }
        public string StreeName { get; set; }
        public string Suburb { get; set; }
        public string City { get; set; }
        public int PostalCode { get; set; }
        public string TelWork { get; set; }
        public string TelMobile { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public string LastName { get; set; }
        public string IDNumber { get; set; }
    }
}
