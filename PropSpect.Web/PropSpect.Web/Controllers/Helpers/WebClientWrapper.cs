﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;

namespace PropSpect.Web.Controllers.Helpers
{
    public static class ApiWrapper
    {
        public static string ApiUrl = "http://propspectapi/";

        public static T Get<T>(string url)
        {
            T response;

            using (WebClient wc = new WebClient())
            {
                response = JsonConvert.DeserializeObject<T>(wc.DownloadString(ApiUrl+ url));
            }

            return response;
        }

        public static T Post<T>(string url,object data)
        {
            WebRequest webRequest = WebRequest.Create(ApiUrl + url);
            webRequest.Method = "POST";
            webRequest.ContentType = "application/json";

            Stream reqStream = null;

            reqStream = webRequest.GetRequestStream();
            byte[] postArray = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(data));
            reqStream.Write(postArray, 0, postArray.Length);

            StreamReader sr = null;

            var webResponse = webRequest.GetResponse();
            sr = new StreamReader(webResponse.GetResponseStream());
            string response = sr.ReadToEnd();

            return JsonConvert.DeserializeObject<T>(response);
        }
    }
}