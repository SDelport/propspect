using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropSpect.Api.Models.Request
{
    public class ChangePasswordRequestRequest
    {
        public string Email { get; set; }
        public int UserID { get; set; }
    }
}
