using Microsoft.AspNetCore.Mvc;
using BugTracker.Models;
using MyWebApi.Models;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Threading.Tasks;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BugTracker.Controllers
{

	[Route("api/[controller]")]
	public class BugController : ControllerBase
    {
		private readonly MyWebApiContext _context;

		public BugController(MyWebApiContext context)
		{
			_context = context;

		}

		[HttpGet]
		public List<Bug> GetAll()
        {
			return _context.bugs.ToList();
        }
  
		[HttpGet("{id}", Name = "GetTask")]
        public IActionResult GetById(long id)
        {
			var item = _context.bugs.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

		[HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
			var bugs = _context.bugs.Find(id);
            if (bugs == null)
            {
                return NotFound();
            }

			_context.bugs.Remove(bugs);
            _context.SaveChanges();
            return NoContent();
        }


		[HttpPost]
		public IActionResult Create([FromBody] Bug item)
        {
            if (item == null)
            {
                return BadRequest();
            }

			_context.bugs.Add(item);
            _context.SaveChanges();

            return CreatedAtRoute("GetTask", new { id = item.Id }, item);
        }

		[HttpPut("{id}")]
		public IActionResult Update(long id, [FromBody] Bug item)
        {
            if (item == null || item.Id != id)
            {
                return BadRequest();
            }

			var bugs = _context.bugs.Find(id);
            if (bugs == null)
            {
                return NotFound();
            }

			bugs.Title = item.Title;
			bugs.Description = item.Description;

			_context.bugs.Update(bugs);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
