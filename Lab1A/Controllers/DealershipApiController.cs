// I, Nigel Reimer, student number 000730702, certify that this material is my
// original work. No other person's work has been used without due
// acknowledgement and I have not made my work available to anyone else.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab1A.Data;
using Lab1A.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Lab1A.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DealershipApiController : ControllerBase
    {
        private static DealershipMgr _dealershipMgr;

        public DealershipApiController()
        {
            _dealershipMgr = new DealershipMgr();
        }

        // GET: api/DealershipApi
        [HttpGet]
        public IEnumerable<Dealership> Get()
        {
            return _dealershipMgr.Get();
        }

        // GET: api/DealershipApi/5
        [HttpGet("{id}", Name = "Get")]
        public Dealership Get(int id)
        {
            return _dealershipMgr.Get(id);
        }

        // POST: api/DealershipApi
        [HttpPost]
        public void Post([FromBody] string dealership)
        {
            _dealershipMgr.Post(JsonConvert.DeserializeObject<Dealership>(dealership));
        }

        // PUT: api/DealershipApi/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string dealership)
        {
            _dealershipMgr.Put(id, JsonConvert.DeserializeObject<Dealership>(dealership));
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _dealershipMgr.Delete(id);
        }
    }
}
