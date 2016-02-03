﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PropSpect.Web.Models.FormModels
{
    public class InspectionFormModel
    {
        public List<ReviewItemFormModel> Rooms { get; set; }

        public InspectionFormModel()
        {
            Rooms = new List<ReviewItemFormModel>();
        }
    }
}