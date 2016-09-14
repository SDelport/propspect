using PropSpect.Api.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PropSpect.Web.Models.FormModels
{
    public class LandlordTemplateAreaItem
    {
        public string Name { get; set; }
        public int Order { get; set; }

        public LandlordTemplateAreaItem()
        {

        }
        public LandlordTemplateAreaItem(string Name,int Order)
        {
            this.Name = Name;
            this.Order = Order;
        }
        public LandlordTemplateAreaItem(LandlordTemplateAreaItemResponse response)
        {
            this.Name = response.ItemName;
            this.Order = response.ItemOrder;
        }
        public static List<LandlordTemplateAreaItem> CreateList(List<LandlordTemplateAreaItemResponse> responseList)
        {
            List<LandlordTemplateAreaItem> list = new List<LandlordTemplateAreaItem>();
            foreach (var response in responseList)
            {
                list.Add(new LandlordTemplateAreaItem(response));
            }
            return list;
        }
    }
}