using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropSpect.Api.Models.Request
{
    public class CreatePropertyRequest
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
