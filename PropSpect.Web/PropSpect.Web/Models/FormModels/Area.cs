using PropSpect.Api.Models.Response;
using PropSpect.Web.Controllers.Helpers.CustomWebViewPageEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PropSpect.Web.Models.FormModels
{
    public class Area
    {
        [EditOptions(Type = ControlType.Hidden)]
        public int AreaID { get; set; }
        public string Name { get; set; }
        public int PropertyID { get; set; }

        public static Area Create(AreaResponse response)
        {
            if (response == null)
                return null;

            Area user = new Area();
            user.AreaID = response.AreaID;
            user.Name = response.Name;
            user.PropertyID = response.PropertyID;
            return user;

        }
        public Area()
        {

        }
        public Area(AreaResponse response)
        {
            this.AreaID = response.AreaID;
            this.Name = response.Name;
            this.PropertyID = response.PropertyID;
        }
        public Area(int AreaID,string Name,int propertyID)
        {
            this.AreaID = AreaID;
            this.Name = Name;
            this.PropertyID = propertyID;
        }
        public static List<Area> CreateList(List<AreaResponse> response)
        {
            if (response == null)
                return null;

            List<Area> users = new List<Area>();
            foreach (var user in response)
            {
                users.Add(Create(user));
            }
            return users;
        }
    }
}