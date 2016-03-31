using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropSpect.Api.Models.Response
{
    public class ForgotPasswordResponse
    {
        public string Email { get; set; }
        public DateTime ExpiryDate { get; set; }
    }
}
