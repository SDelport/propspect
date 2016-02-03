using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PropSpect.Web.Models.FormModels
{
    public class ReviewItemCharacteristicFormModel
    {
        public string Name { get; set; }
        public int ConditionID { get; set; }
        public int TempImageID { get; set; }
    }
}