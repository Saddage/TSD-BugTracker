using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BugTracker.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BugTracker.Controllers
{
    public class BugController : Controller
    {
        private static readonly IList<Bug> _bugs;

        static BugController()
        {
            _bugs = new List<Bug>
            {
                new Bug
                {
                    Id = 1,
                    Title = "Bug buggowsky",
                    Description = "Hello buggy bug!"
                },
                new Bug
                {
                    Id = 2,
                    Title = "Bugg Bug bug",
                    Description = "This is one bug"
                },
                new Bug
                {
                    Id = 3,
                    Title = "bububugbu",
                    Description = "This is *another* bug"
                },
            }; 
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        [Route("bugs")]
        [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
        public ActionResult Comments()
        {
            return Json(_bugs);
        }
    }
}
