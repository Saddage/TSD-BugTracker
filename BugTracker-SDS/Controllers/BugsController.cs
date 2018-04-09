using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BugTrackerSDS.Models;

namespace BugTracker_SDS.Controllers
{
    [Route("api/[controller]")]
    public class BugsController : Controller
    {
        Bug[] bugs = new Bug[]
        {
            new Bug { ID = 1, title = "Some bug", description = "Jakis bug w aplikacji co odpierdala"},
            new Bug { ID = 2, title = "Some bug2", description = "Jakis bug w aplikacji co odpierdala"},
            new Bug { ID = 3, title = "Some bug3", description = "Jakis bug w aplikacji co odpierdala"}
        };

        // GET api/bugs/
        [HttpGet]
        public Bug[] Get()
        {
            return bugs;
        }

        // GET api/bugs/5
        [HttpGet("{id}")]
        public Bug Get(int id)
        {
            var bug = bugs.Where(b => b.ID == id);
            return (BugTrackerSDS.Models.Bug)bug;
        }

        // POST api/bugs
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/bugs/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/bugs/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
