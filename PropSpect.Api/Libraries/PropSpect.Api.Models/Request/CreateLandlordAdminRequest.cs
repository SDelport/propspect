using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropSpect.Api.Models.Request
{
    public class CreateLandlordAdminRequest
    {
        public int LandlordAdminID { get; set; }
        public string FirstName { get; set; }
        public string PreferredName { get; set; }
        public string LastName { get; set; }
        public string IDNumber { get; set; }
        public string TelWork { get; set; }
        public string TelMobile { get; set; }
        public string Email { get; set; }
        public int UserKey { get; set; }
    }
}
