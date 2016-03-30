using PropSpect.Api.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropSpect.Api.Models.Helpers
{
    public static class Associations
    {
        public static LoginRole GetLoginRole(string role)
        {
            role = role.ToLower();

            if (role == "a" || role == "admin")
                return LoginRole.Admin;
            if (role == "sa" || role == "superadmin")
                return LoginRole.SuperAdmin;
            if (role == "t" || role == "tenant")
                return LoginRole.Tenant;
            if (role == "ag" || role == "agent")
                return LoginRole.Agent;
            if (role == "o" || role == "owner")
                return LoginRole.Owner;
            if (role == "t" || role == "tenant")
                return LoginRole.Tenant;

            return LoginRole.None;
        }

        public static LoginRole GetLoginRole(int role)
        {
            try
            {
                return (LoginRole)role;
            }
            catch 
            {
            }

            return LoginRole.None;
        }

        public static string GetLoginRole(LoginRole role)
        {
            switch (role)
            {
                case LoginRole.SuperAdmin:
                    return "sa";
                case LoginRole.Agent:
                    return "ag";
                case LoginRole.Tenant:
                    return "t";
                case LoginRole.Landlord:
                    return "l";
                case LoginRole.None:
                    return "";
                case LoginRole.Owner:
                    return "o";
                case LoginRole.Admin:
                    return "a";
                default:
                    return "";
            }
           
        }

        public static int GetLoginRoleIndex(string role)
        {
            return (int)(GetLoginRole(role));
        }
    }
}
