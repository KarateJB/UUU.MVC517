using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Mvc517.Website.Controllers
{
    public class RestApiController : ApiController
    {
        // GET: api/RestApi
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/RestApi/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/RestApi
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/RestApi/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/RestApi/5
        public void Delete(int id)
        {
        }
    }
}
