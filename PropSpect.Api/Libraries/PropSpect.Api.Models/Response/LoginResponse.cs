using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropSpect.Api.Models.Response
{
    public enum LoginRole
    {
        SuperAdmin = 0,
        Agent,
        Tenant,
        Landlord,
        None,
        Owner,
        Admin
    }

    public class LoginResponse
    { 
        public string UserID { get; set; }
        public LoginRole Role { get; set; }
        public string Username { get; set; }
    }

    
}
