using PropSpect.Api.Models.Response;
using PropSpect.Web.Controllers.Helpers.CustomWebViewPageEngine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace PropSpect.Web.Models.FormModels
{
    public class AreaItem
    {
        [ListOptions(Hide = true)]
        [EditOptions(Type = ControlType.Hidden)]
        public int AreaItemID { get; set; }


        [ListOptions(Display = "Item")]
        [EditOptions(Display = "Item")]
        public string RoomItem { get; set; }
        [ListOptions(Display = "Description")]
        [EditOptions(Display = "Description")]
        public string RoomDescription { get; set; }
        [EditOptions(Type = ControlType.Dropdown, SourceName = "AreaItems", Display = "Area")]
        [ListOptions(SourceName = "AreaItems", Display = "Area")]
        public int AreaID { get; set; }

        public static AreaItem Create(AreaItemResponse response)
        {
            if (response == null)
                return null;

            AreaItem user = new AreaItem();
            user.AreaItemID = response.AreaItemID;
            user.RoomItem = response.RoomItem;
            user.RoomDescription = response.RoomDescription;
            user.AreaID = response.AreaID;

            return user;

        }
        public AreaItem()
        {

        }
        public AreaItem(AreaItemResponse response)
        {
            this.AreaID = response.AreaID;
            this.AreaItemID = response.AreaItemID;
            this.RoomDescription = response.RoomDescription;
            this.RoomItem = response.RoomItem;
        }
        public AreaItem(int AreaID,int AreaItemID,string RoomDescription,string RoomItem)
        {
            this.AreaID = AreaID;
            this.AreaItemID = AreaItemID;
            this.RoomDescription = RoomDescription;
            this.RoomItem = RoomItem;
        }
        public static List<AreaItem> CreateList(List<AreaItemResponse> response)
        {
            if (response == null)
                return null;

            List<AreaItem> users = new List<AreaItem>();
            foreach (var user in response)
            {
                users.Add(Create(user));
            }
            return users;
        }
    }
}