using PropSpect.Api.Data;
using PropSpect.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;

namespace PropSpect.Api.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values

        DatabaseContext db = new DatabaseContext();

        public JsonResult<List<string>> Get()
        {
            List<string> values = new List<string>() { "test", "test2" };

            var landlords = db.LandLords.ToList();
        

            return Json(values);
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
