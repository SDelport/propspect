using PropSpect.Api.Models.Helpers;
using PropSpect.Api.Models.Request;
using PropSpect.Api.Models.Response;
using PropSpect.Web.Controllers.Helpers;
using PropSpect.Web.Models.FormModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web.Mvc;

namespace PropSpect.Web.Controllers
{
    public class UserController : Controller
    {
        [Route("user/add/a")]
        public ActionResult AddAdmin()
        {
            Models.FormModels.User user = new Models.FormModels.User();
            user.Type = Associations.GetLoginRole(LoginRole.Admin);

            return View("Create", user);
        }

        [Route("user/add/t/{tenantID?}")]
        [Route("user/add/tenant/{tenantID?}")]
        public ActionResult AddTenant(int tenantID = 0)
        {
            Tenant tenant = new Models.FormModels.Tenant();
            tenant.Type = Associations.GetLoginRole(LoginRole.Tenant);

            if (tenantID > 0)
            {
                TenantResponse tenantResponse = ApiWrapper.Get<TenantResponse>("api/tenant/get/" + tenantID);
                UserResponse userResponse = userResponse = ApiWrapper.Get<UserResponse>("api/user/getbykey/" + tenantID);
                if (tenantResponse != null && userResponse != null)
                {
                    tenant.TenantID = tenantResponse.TenantID;
                    tenant.Title = tenantResponse.Title;
                    tenant.FirstName = tenantResponse.FirstName;
                    tenant.SecondName = tenantResponse.SecondName;
                    tenant.ThirdName = tenantResponse.ThirdName;
                    tenant.PreferredName = tenantResponse.PreferredName;
                    tenant.LastName = tenantResponse.LastName;
                    tenant.IDNumber = tenantResponse.IDNumber;
                    tenant.TelWork = tenantResponse.TelWork;
                    tenant.TelMobile = tenantResponse.TelMobile;
                    tenant.Email = tenantResponse.Email;
                    tenant.Website = tenantResponse.Website;
                    tenant.UserID = userResponse.UserID;
                    tenant.Username = userResponse.Username;
                    tenant.Type = userResponse.Type;
                }
                else
                    return HttpNotFound();
            }

            return View("Tenant/Create", tenant);
        }

        [Route("user/add/ag/{agentID?}")]
        [Route("user/add/agent/{agentID?}")]
        public ActionResult AddAgent(int agentID = 0)
        {
            LandlordAgent landlordAgent = new LandlordAgent();
            landlordAgent.Type = Associations.GetLoginRole(LoginRole.Agent);

            if (agentID > 0)
            {
                LandlordAgentResponse landlordAgentResponse = ApiWrapper.Get<LandlordAgentResponse>("api/landlordagent/" + agentID);
                UserResponse userResponse = userResponse = ApiWrapper.Get<UserResponse>("api/user/getbykey/" + agentID);
                if (landlordAgentResponse != null && userResponse != null)
                {
                    landlordAgent.LandlordAgentID = landlordAgentResponse.LandlordAgentID;
                    landlordAgent.FirstName = landlordAgentResponse.FirstName;
                    landlordAgent.PreferredName = landlordAgentResponse.PreferredName;
                    landlordAgent.LastName = landlordAgentResponse.LastName;
                    landlordAgent.IDNumber = landlordAgentResponse.IDNumber;
                    landlordAgent.TelWork = landlordAgentResponse.TelWork;
                    landlordAgent.TelMobile = landlordAgentResponse.TelMobile;
                    landlordAgent.Email = landlordAgentResponse.Email;
                    landlordAgent.UserKey = landlordAgentResponse.LandlordAgentID;
                    landlordAgent.UserID = userResponse.UserID;
                    landlordAgent.Username = userResponse.Username;
                    landlordAgent.Type = userResponse.Type;
                }
                else
                    return HttpNotFound();
            }

            return View("Agent/Create", landlordAgent);
        }

        [Route("user/add/a/{adminID?}")]
        [Route("user/add/admin/{adminID?}")]
        public ActionResult AddAdmin(int adminID = 0)
        {
            LandlordAdmin landlordAdmin = new LandlordAdmin();
            landlordAdmin.Type = Associations.GetLoginRole(LoginRole.Admin);

            if (adminID > 0)
            {
                LandlordAdminResponse landlordAdminResponse = ApiWrapper.Get<LandlordAdminResponse>("api/landlordadmin/" + adminID);
                UserResponse userResponse = userResponse = ApiWrapper.Get<UserResponse>("api/user/getbykey/" + adminID);
                if (landlordAdminResponse != null && userResponse != null)
                {
                    landlordAdmin.LandlordAdminID = landlordAdminResponse.LandlordAdminID;
                    landlordAdmin.FirstName = landlordAdminResponse.FirstName;
                    landlordAdmin.PreferredName = landlordAdminResponse.PreferredName;
                    landlordAdmin.LastName = landlordAdminResponse.LastName;
                    landlordAdmin.IDNumber = landlordAdminResponse.IDNumber;
                    landlordAdmin.TelWork = landlordAdminResponse.TelWork;
                    landlordAdmin.TelMobile = landlordAdminResponse.TelMobile;
                    landlordAdmin.Email = landlordAdminResponse.Email;
                    landlordAdmin.UserKey = landlordAdminResponse.LandlordAdminID;
                    landlordAdmin.UserID = userResponse.UserID;
                    landlordAdmin.Username = userResponse.Username;
                    landlordAdmin.Type = userResponse.Type;
                }
                else
                    return HttpNotFound();
            }

            return View("Admin/Create", landlordAdmin);
        }

        [Route("user/delete/owner/{ownerID}")]
        public ActionResult DeleteOwner(int ownerID)
        {
            var response = ApiWrapper.Get<bool>("api/owner/delete/" + ownerID);
            if (response)
                ApiWrapper.Get<bool>("api/user/deletebykey/" + ownerID);

            return Redirect("/user/list/owner");
        }

        [Route("user/delete/agent/{agentID}")]
        public ActionResult DeleteAgent(int agentID)
        {
            var response = ApiWrapper.Get<bool>("api/landlordagent/delete/" + agentID);
            if (response)
                ApiWrapper.Get<bool>("api/user/deletebykey/" + agentID);

            return Redirect("/user/list/agent");
        }

        [Route("user/delete/tenant/{tenantID}")]
        public ActionResult DeleteTenant(int tenantID)
        {
            var response = ApiWrapper.Get<bool>("api/tenant/delete/" + tenantID);
            if (response)
                ApiWrapper.Get<bool>("api/user/deletebykey/" + tenantID);

            return Redirect("/user/list/tenant");
        }

        [Route("user/delete/admin/{adminID}")]
        public ActionResult DeleteAdmin(int adminID)
        {
            var response = ApiWrapper.Get<bool>("api/landlordadmin/delete/" + adminID);
            if (response)
                ApiWrapper.Get<bool>("api/user/deletebykey/" + adminID);

            return Redirect("/user/list/admin");
        }

        [Route("user/add/o/{ownerID?}")]
        [Route("user/add/owner/{ownerID?}")]
        public ActionResult AddOwner(int ownerID = 0)
        {
            Owner owner = new Models.FormModels.Owner();
            owner.Type = Associations.GetLoginRole(LoginRole.Owner);

            if (ownerID > 0)
            {
                OwnerResponse ownerResponse = ApiWrapper.Get<OwnerResponse>("api/owner/get/" + ownerID);
                UserResponse userResponse = userResponse = ApiWrapper.Get<UserResponse>("api/user/getbykey/" + ownerID);
                if (ownerResponse != null && userResponse != null)
                {
                    owner.OwnerID = ownerResponse.OwnerID;
                    owner.OwnerType = ownerResponse.Type;
                    owner.Name = ownerResponse.Name;
                    owner.UnitNr = ownerResponse.UnitNr;
                    owner.ComplexName = ownerResponse.ComplexName;
                    owner.StreetNumber = ownerResponse.StreetNumber;
                    owner.StreetName = ownerResponse.StreeName;
                    owner.Suburb = ownerResponse.Suburb;
                    owner.City = ownerResponse.City;
                    owner.PostalCode = ownerResponse.PostalCode;
                    owner.TelWork = ownerResponse.TelWork;
                    owner.TelMobile = ownerResponse.TelMobile;
                    owner.Fax = ownerResponse.Fax;
                    owner.Email = ownerResponse.Email;
                    owner.Website = ownerResponse.Website;
                    owner.Title = ownerResponse.Title;
                    owner.FirstName = ownerResponse.FirstName;
                    owner.SecondName = ownerResponse.SecondName;
                    owner.ThirdName = ownerResponse.ThirdName;
                    owner.LastName = ownerResponse.LastName;
                    owner.IDNumber = ownerResponse.IDNumber;
                    owner.UserID = userResponse.UserID;
                    owner.Username = userResponse.Username;
                    owner.Type = userResponse.Type;
                }
                else
                    return HttpNotFound();
            }

            return View("Owner/Create", owner);
        }

        [Route("user/list/o")]
        [Route("user/list/owner")]
        public ActionResult ViewOwners()
        {
            List<UserResponse> users = new List<UserResponse>();
            users = ApiWrapper.Get<List<UserResponse>>("api/user/list/owner");
            List<OwnerResponse> owners = new List<OwnerResponse>();
            owners = ApiWrapper.Get<List<OwnerResponse>>("api/owner/");

            List<Owner> finalOwners = new List<Owner>();

            foreach (OwnerResponse owner in owners)
            {
                var user = users.Where(x => x.UserKey == owner.OwnerID).FirstOrDefault();

                if (user == null)
                    continue;

                Owner finalOwner = new Owner();
                finalOwner.OwnerID = owner.OwnerID;
                finalOwner.OwnerType = owner.Type;
                finalOwner.Name = owner.Name;
                finalOwner.UnitNr = owner.UnitNr;
                finalOwner.ComplexName = owner.ComplexName;
                finalOwner.StreetNumber = owner.StreetNumber;
                finalOwner.StreetName = owner.StreeName;
                finalOwner.Suburb = owner.Suburb;
                finalOwner.City = owner.City;
                finalOwner.PostalCode = owner.PostalCode;
                finalOwner.TelWork = owner.TelWork;
                finalOwner.TelMobile = owner.TelMobile;
                finalOwner.Fax = owner.Fax;
                finalOwner.Email = owner.Email;
                finalOwner.Website = owner.Website;
                finalOwner.Title = owner.Title;
                finalOwner.FirstName = owner.FirstName;
                finalOwner.SecondName = owner.SecondName;
                finalOwner.ThirdName = owner.ThirdName;
                finalOwner.LastName = owner.LastName;
                finalOwner.IDNumber = owner.IDNumber;
                finalOwner.UserID = user.UserID;
                finalOwner.Username = user.Username;
                finalOwner.Type = user.Type;

                finalOwners.Add(finalOwner);
            }

            return View("Owner/List", finalOwners);
        }

        [Route("user/list/t")]
        [Route("user/list/tenant")]
        public ActionResult ViewTenants()
        {
            List<UserResponse> users = new List<UserResponse>();
            users = ApiWrapper.Get<List<UserResponse>>("api/user/list/tenant");
            List<TenantResponse> tenants = new List<TenantResponse>();
            tenants = ApiWrapper.Get<List<TenantResponse>>("api/tenant/");

            List<Tenant> finalTenants = new List<Tenant>();

            foreach (TenantResponse tenant in tenants)
            {
                var user = users.Where(x => x.UserKey == tenant.TenantID).FirstOrDefault();

                if (user == null)
                    continue;

                Tenant finalTenant = new Tenant();
                finalTenant.TenantID = tenant.TenantID;
                finalTenant.Title = tenant.Title;
                finalTenant.FirstName = tenant.FirstName;
                finalTenant.SecondName = tenant.SecondName;
                finalTenant.ThirdName = tenant.ThirdName;
                finalTenant.PreferredName = tenant.PreferredName;
                finalTenant.LastName = tenant.LastName;
                finalTenant.IDNumber = tenant.IDNumber;
                finalTenant.TelWork = tenant.TelWork;
                finalTenant.TelMobile = tenant.TelMobile;
                finalTenant.Email = tenant.Email;
                finalTenant.Website = tenant.Website;
                finalTenant.UserID = user.UserID;
                finalTenant.Username = user.Username;
                finalTenant.Type = user.Type;

                finalTenants.Add(finalTenant);
            }

            return View("Tenant/List", finalTenants);
        }

        [Route("user/list/ag")]
        [Route("user/list/agent")]
        public ActionResult ViewAgents()
        {
            List<UserResponse> users = new List<UserResponse>();
            users = ApiWrapper.Get<List<UserResponse>>("api/user/list/agent");
            List<LandlordAgentResponse> landlordAgents = new List<LandlordAgentResponse>();
            landlordAgents = ApiWrapper.Get<List<LandlordAgentResponse>>("api/landlordagent/");

            List<LandlordAgent> finalLandlordAgents = new List<LandlordAgent>();

            foreach (LandlordAgentResponse agent in landlordAgents)
            {
                var user = users.Where(x => x.UserKey == agent.LandlordAgentID).FirstOrDefault();

                if (user == null)
                    continue;

                LandlordAgent finalAgent = new LandlordAgent();
                finalAgent.LandlordAgentID = agent.LandlordAgentID;
                finalAgent.FirstName = agent.FirstName;
                finalAgent.PreferredName = agent.FirstName;
                finalAgent.LastName = agent.LastName;
                finalAgent.IDNumber = agent.IDNumber;
                finalAgent.TelWork = agent.TelWork;
                finalAgent.TelMobile = agent.TelMobile;
                finalAgent.Email = agent.Email;
                finalAgent.UserKey = agent.LandlordAgentID;
                finalAgent.UserID = user.UserID;
                finalAgent.Username = user.Username;
                finalAgent.Type = user.Type;

                finalLandlordAgents.Add(finalAgent);
            }

            return View("Agent/List", finalLandlordAgents);
        }


        [Route("user/list/a")]
        [Route("user/list/admin")]
        public ActionResult ViewAdmin()
        {
            List<UserResponse> users = new List<UserResponse>();
            users = ApiWrapper.Get<List<UserResponse>>("api/user/list/admin");
            List<LandlordAdminResponse> landlordAdmins = new List<LandlordAdminResponse>();
            landlordAdmins = ApiWrapper.Get<List<LandlordAdminResponse>>("api/landlordadmin/");

            List<LandlordAdmin> finalLandlordAdmins = new List<LandlordAdmin>();

            foreach (LandlordAdminResponse admin in landlordAdmins)
            {
                var user = users.Where(x => x.UserKey == admin.LandlordAdminID).FirstOrDefault();

                if (user == null)
                    continue;

                LandlordAdmin finalAdmin = new LandlordAdmin();
                finalAdmin.LandlordAdminID = admin.LandlordAdminID;
                finalAdmin.FirstName = admin.FirstName;
                finalAdmin.PreferredName = admin.FirstName;
                finalAdmin.LastName = admin.LastName;
                finalAdmin.IDNumber = admin.IDNumber;
                finalAdmin.TelWork = admin.TelWork;
                finalAdmin.TelMobile = admin.TelMobile;
                finalAdmin.Email = admin.Email;
                finalAdmin.UserKey = admin.LandlordAdminID;
                finalAdmin.UserID = user.UserID;
                finalAdmin.Username = user.Username;
                finalAdmin.Type = user.Type;

                finalLandlordAdmins.Add(finalAdmin);
            }

            return View("Admin/List", finalLandlordAdmins);
        }

        [Route("user/list/{type?}")]
        public ActionResult ViewUsers(string type = "")
        {
            List<User> users = new List<User>();
            users = Models.FormModels.User.CreateList(ApiWrapper.Get<List<UserResponse>>("api/user/list/" + type));
            AdminAddUser model = new AdminAddUser();
            model.Users = users;
            if (!string.IsNullOrEmpty(type))
                model.Type = Associations.GetLoginRole(type);

            return View("List", model);
        }

        [Route("user/setpassword/{guid}")]
        public ActionResult SetPass(string guid)
        {
            Guid g;

            if (!Guid.TryParse(guid, out g))
                return HttpNotFound();

            SetPassword model = new SetPassword();
            model.Key = guid;

            return View("SetPassword", model);
        }

        [Route("user/requestpassword")]
        public ActionResult RequestPass()
        {
            return View("RequestPasswordChange");
        }

        [Route("user/requestpassword/post")]
        public ActionResult RequestPass(string email)
        {
            ChangePasswordRequestRequest request = new ChangePasswordRequestRequest();
            request.Email = email;

            var key = ApiWrapper.Post<string>("api/user/requestchange", request);

            return Redirect("/");
        }


        [Route("user/test")]
        public JsonResult ResetPass()
        {
            MailMessage mail = new MailMessage("noreply@propspect.co.za", "delport.stefan@gmail.com");
            SmtpClient client = new SmtpClient();
            client.Port = 25;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Host = "smtp.webafrica.co.za";
            mail.Subject = "this is a test email.";
            mail.Body = "this is my test email body";
            client.Send(mail);

            return Json(true);
        }
    }
}