using PropSpect.Api.Models.Helpers;
using PropSpect.Api.Models.Response;
using PropSpect.Web.Controllers.Helpers.CustomWebViewPageEngine;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PropSpect.Web.Models.FormModels
{
    public class User
    {
        [ListOptions(Hide = true)]
        public int UserID { get; set; }
        [EmailAddress]
        public string Username { get; set; }
        [ListOptions(Hide = true)]
        [EditOptions(Type = ControlType.Dropdown, SourceName = "RoleItems")]
        public string Type { get; set; }
        [ListOptions(Hide = true)]
        public string Password { get; set; }
        [ListOptions(Hide = true)]
        public bool IsPasswordChanged { get; set; }

        public string Language { get; set; }

        public static User Create(UserResponse response)
        {
            if (response == null)
                return null;

            User user = new User();
            user.UserID = response.UserID;
            user.Username = response.Username;
            user.Password = response.Password;
            user.IsPasswordChanged = response.IsPasswordChanged;
            user.Language = response.Language;
            user.Type = response.Type;

            return user;

        }

        public static List<User> CreateList(List<UserResponse> response)
        {
            if (response == null)
                return null;

            List<User> users = new List<User>();
            foreach (var user in response)
            {
                users.Add(Create(user));
            }
            return users;
        }

    }
}