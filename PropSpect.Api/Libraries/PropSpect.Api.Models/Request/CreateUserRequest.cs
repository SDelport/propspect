using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropSpect.Api.Models.Request
{
    public class CreateUserRequest
    {
        public int UserID { get; set; }
        public int UserKey { get; set; }
        public string Username { get; set; }
        public string Type { get; set; }
        public string Language { get; set; }

    }
}
