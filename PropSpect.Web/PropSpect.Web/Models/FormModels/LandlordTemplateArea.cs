using PropSpect.Api.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PropSpect.Web.Models.FormModels
{
    public class LandlordTemplateArea
    {
        public string Name { get; set; }
        public int Order { get; set; }
        public int LandlordTemplateAreaID { get; set; }
        public List<LandlordTemplateAreaItem> Items { get; set; }

        public LandlordTemplateArea()
        {

        }
        public LandlordTemplateArea(string Name,int Order,int LandLordTempID)
        {
            this.Name = Name;
            this.Order = Order;
            this.LandlordTemplateAreaID = LandLordTempID;
        }
        public LandlordTemplateArea(LandlordTemplateAreaResponse response)
        {
            this.Name = response.AreaName;
            this.Order = response.AreaOrder;
            this.LandlordTemplateAreaID = response.LandlordTemplateAreaID;
            this.Items = LandlordTemplateAreaItem.CreateList(response.Items);
        }
        public static List<LandlordTemplateArea> CreateList(List<LandlordTemplateAreaResponse> responseList)
        {
            List<LandlordTemplateArea> list = new List<LandlordTemplateArea>();
            foreach (var response in responseList)
            {
                list.Add(new LandlordTemplateArea(response));
            }
            return list;
        }
    }
}