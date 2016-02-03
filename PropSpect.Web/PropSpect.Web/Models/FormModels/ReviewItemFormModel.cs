using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PropSpect.Web.Models.FormModels
{
    public class ReviewItemFormModel
    {
        public string Name { get; set; }
        public int ReviewItemTypeID { get; set; }
        public List<ReviewItemCharacteristicFormModel> ReviewItemParts { get; set; }

        public List<SelectListItem> ConditionItems { get; set; }

        public ReviewItemFormModel()
        {
            ReviewItemParts = new List<ReviewItemCharacteristicFormModel>();
            ConditionItems = new List<SelectListItem>();
        }

        public int PageID { get; set; }
        public int Number { get; set; }
        public int Total { get; set; }
    }
}