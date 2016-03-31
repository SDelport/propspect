using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropSpect.Api.Models.Request
{
    public class ResetPasswordRequest
    {
        public string Key { get; set; }
        public string Password { get; set; }
        
    }
}
