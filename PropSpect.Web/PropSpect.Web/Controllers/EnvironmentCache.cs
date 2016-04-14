using PropSpect.Api.Models.Response;
using PropSpect.Web.Controllers.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PropSpect.Web.Controllers
{
    public static class EnvironmentCache
    {
        public static List<EnvironmentValueResponse> EnvironmentValues
        {
            get
            {
                if (vals == null)
                    Load();

                return vals;
            }
            private set
            {
            }
        }

        private static List<EnvironmentValueResponse> vals;

        public static List<EnvironmentValueResponse> GetDisplayValues(string category)
        {
            return EnvironmentValues.Where(x => x.Type == category).ToList();
        }

        public static string GetID(string displayValue, string category)
        {
            return EnvironmentValues.Where(x => x.Type == category).Where(x => x.Display == displayValue).Select(x => x.ID).FirstOrDefault();
        }

        public static string GetDisplayValue(string ID, string category)
        {
            return EnvironmentValues.Where(x => x.Type == category).Where(x => x.ID == ID).Select(x => x.Display).FirstOrDefault();
        }

        private static void Load()
        {
            vals = new List<EnvironmentValueResponse>();

            vals = ApiWrapper.Get<List<EnvironmentValueResponse>>("api/environment/all");
        }
    }
}