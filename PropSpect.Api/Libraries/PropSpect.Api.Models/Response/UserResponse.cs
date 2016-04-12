using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropSpect.Api.Models.Response
{
  

    public class UserResponse
    {
        public int UserID { get; set; }
        public int UserKey { get; set; }
        public string Username { get; set; }
        public string Type { get; set; }
        public string Password { get; set; }
        public bool IsPasswordChanged { get; set; }
        public string Language { get; set; }
    }
}
