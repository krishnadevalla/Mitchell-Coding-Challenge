using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MitchellWebApi.Controllers
{
    public class VehiclesController : ApiController
    {
        // GET: api/Vehicles
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Vehicles/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Vehicles
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Vehicles/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Vehicles/5
        public void Delete(int id)
        {
        }
    }
}
