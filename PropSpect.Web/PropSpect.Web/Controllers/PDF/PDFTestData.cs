using PropSpect.Web.Models.FormModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PropSpect.Web.Controllers.PDF
{
    public class PDFTestData
    {
        public List<InspectionAreaItem> FrontDoor { get; set; }
        public List<InspectionAreaItem> Hallway { get; set; }
        public List<InspectionAreaItem> Kitchen { get; set; }

        public PDFTestData()
        {
            FrontDoor = new List<InspectionAreaItem>();
            FrontDoor.Add(new InspectionAreaItem { ItemDescription = "Door", ItemCondition = "Good", ItemRepair = "-" });
            FrontDoor.Add(new InspectionAreaItem { ItemDescription = "Door Frame", ItemCondition = "Exellent", ItemRepair = "-" });
            FrontDoor.Add(new InspectionAreaItem { ItemDescription = "Door Lock", ItemCondition = "Bad", ItemRepair = "Yes" });
            FrontDoor.Add(new InspectionAreaItem { ItemDescription = "Door Key Code", ItemCondition = "Good", ItemRepair = "-" });
            FrontDoor.Add(new InspectionAreaItem { ItemDescription = "Door Stopper", ItemCondition = "Good", ItemRepair = "-" });
            FrontDoor.Add(new InspectionAreaItem { ItemDescription = "Outside Light", ItemCondition = "Okay", ItemRepair = "Yes" });


            Hallway = new List<InspectionAreaItem>();
            Hallway.Add(new InspectionAreaItem { ItemDescription = "Carpet/Tiles", ItemCondition = "Good", ItemRepair = "-" });
            Hallway.Add(new InspectionAreaItem { ItemDescription = "Ceiling", ItemCondition = "Good", ItemRepair = "-" });
            Hallway.Add(new InspectionAreaItem { ItemDescription = "Skirting", ItemCondition = "Okay", ItemRepair = "Yes" });
            Hallway.Add(new InspectionAreaItem { ItemDescription = "Light Bulb", ItemCondition = "Bad", ItemRepair = "Yes" });
            Hallway.Add(new InspectionAreaItem { ItemDescription = "Light Fiting", ItemCondition = "Good", ItemRepair = "-" });
            Hallway.Add(new InspectionAreaItem { ItemDescription = "Light Fixture", ItemCondition = "Ecellent", ItemRepair = "-" });
            Hallway.Add(new InspectionAreaItem { ItemDescription = "Light Switch", ItemCondition = "Good", ItemRepair = "-" });
            Hallway.Add(new InspectionAreaItem { ItemDescription = "Electrical Plugs", ItemCondition = "Greate", ItemRepair = "-" });
            Hallway.Add(new InspectionAreaItem { ItemDescription = "Window", ItemCondition = "Good", ItemRepair = "-" });
            Hallway.Add(new InspectionAreaItem { ItemDescription = "Window Handles & Sliders", ItemCondition = "Bad", ItemRepair = "Yes" });
            Hallway.Add(new InspectionAreaItem { ItemDescription = "Window Rail", ItemCondition = "Good", ItemRepair = "-" });
            Hallway.Add(new InspectionAreaItem { ItemDescription = "Walls", ItemCondition = "Good", ItemRepair = "-" });
            Hallway.Add(new InspectionAreaItem { ItemDescription = "Nails, Skrews & Hooks", ItemCondition = "Good", ItemRepair = "-" });
            Hallway.Add(new InspectionAreaItem { ItemDescription = "Cupboard", ItemCondition = "Bad", ItemRepair = "Yes" });
            Hallway.Add(new InspectionAreaItem { ItemDescription = "Cupboard Handles", ItemCondition = "Good", ItemRepair = "-" });
            Hallway.Add(new InspectionAreaItem { ItemDescription = "Cupboard Hinges", ItemCondition = "Good", ItemRepair = "-" });
            Hallway.Add(new InspectionAreaItem { ItemDescription = "Shelves of Cupboard", ItemCondition = "Good", ItemRepair = "-" });

            Kitchen = new List<InspectionAreaItem>();
            Kitchen.Add(new InspectionAreaItem { ItemDescription = "Oven", ItemCondition = "Good", ItemRepair = "-" });
            Kitchen.Add(new InspectionAreaItem { ItemDescription = "Oven Pan", ItemCondition = "Good", ItemRepair = "-" });
            Kitchen.Add(new InspectionAreaItem { ItemDescription = "Oven Rubber", ItemCondition = "Okay", ItemRepair = "Yes" });
            Kitchen.Add(new InspectionAreaItem { ItemDescription = "Small Oven Grill", ItemCondition = "Bad", ItemRepair = "Yes" });
            Kitchen.Add(new InspectionAreaItem { ItemDescription = "Large Oven Grills", ItemCondition = "Good", ItemRepair = "-" });
            Kitchen.Add(new InspectionAreaItem { ItemDescription = "Stove", ItemCondition = "Ecellent", ItemRepair = "-" });
            Kitchen.Add(new InspectionAreaItem { ItemDescription = "Manual", ItemCondition = "Good", ItemRepair = "-" });
            Kitchen.Add(new InspectionAreaItem { ItemDescription = "Extractor", ItemCondition = "Greate", ItemRepair = "-" });
            Kitchen.Add(new InspectionAreaItem { ItemDescription = "Extractor Light", ItemCondition = "Good", ItemRepair = "-" });
            Kitchen.Add(new InspectionAreaItem { ItemDescription = "Extractor Fan", ItemCondition = "Bad", ItemRepair = "Yes" });
            Kitchen.Add(new InspectionAreaItem { ItemDescription = "Basin", ItemCondition = "Good", ItemRepair = "-" });
            Kitchen.Add(new InspectionAreaItem { ItemDescription = "Basin Plug", ItemCondition = "Good", ItemRepair = "-" });
            Kitchen.Add(new InspectionAreaItem { ItemDescription = "Basin Taps", ItemCondition = "Good", ItemRepair = "-" });
            Kitchen.Add(new InspectionAreaItem { ItemDescription = "Window", ItemCondition = "Good", ItemRepair = "-" });
            Kitchen.Add(new InspectionAreaItem { ItemDescription = "Window Handles & Sliders", ItemCondition = "Bad", ItemRepair = "Yes" });
            Kitchen.Add(new InspectionAreaItem { ItemDescription = "Window Rail", ItemCondition = "Good", ItemRepair = "-" });
            Kitchen.Add(new InspectionAreaItem { ItemDescription = "Cupboard", ItemCondition = "Bad", ItemRepair = "Yes" });
            Kitchen.Add(new InspectionAreaItem { ItemDescription = "Cupboard Handles", ItemCondition = "Good", ItemRepair = "-" });
            Kitchen.Add(new InspectionAreaItem { ItemDescription = "Cupboard Hinges", ItemCondition = "Good", ItemRepair = "-" });
            Kitchen.Add(new InspectionAreaItem { ItemDescription = "Light Bulb", ItemCondition = "Bad", ItemRepair = "Yes" });
            Kitchen.Add(new InspectionAreaItem { ItemDescription = "Light Fiting", ItemCondition = "Good", ItemRepair = "-" });
            Kitchen.Add(new InspectionAreaItem { ItemDescription = "Door", ItemCondition = "Good", ItemRepair = "-" });
            Kitchen.Add(new InspectionAreaItem { ItemDescription = "Door Frame", ItemCondition = "Exellent", ItemRepair = "-" });
            Kitchen.Add(new InspectionAreaItem { ItemDescription = "Door Lock", ItemCondition = "Bad", ItemRepair = "Yes" });
            Kitchen.Add(new InspectionAreaItem { ItemDescription = "Door Key Code", ItemCondition = "Good", ItemRepair = "-" });
            Kitchen.Add(new InspectionAreaItem { ItemDescription = "Door Stopper", ItemCondition = "Good", ItemRepair = "-" });
        }
    }
}