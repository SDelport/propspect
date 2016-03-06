using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropSpect.Api.Models.Response
{
    public class TenantResponse
    {
        public int TenantID { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public string PreferredName { get; set; }
        public string LastName { get; set; }
        public string IDNumber { get; set; }
        public string TelWork { get; set; }
        public string TelMobile { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
    }
}
