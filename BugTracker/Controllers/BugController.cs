using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BugTracker.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BugTracker.Controllers
{
	[Route("api/[controller]")]
	public class BugController : ControllerBase
    {
		private readonly DatabaseContext _context;

		public BugController(DatabaseContext context)
		{
			_context = context;

		}

		[HttpGet]
		public List<Bug> GetAll()
        {

			return new List<Bug> { 
				new Bug {
                Name = "test",
                Description = "test",
                state = State.toDo,
                priority = Priority.high,
                StoryPoints = 32,
				} };
			//return _context.Bugs.ToList();
        }
  
		[HttpGet("{id}", Name = "GetTask")]
        public IActionResult GetById(long id)
        {
			var item = _context.Bugs.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

		[HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var bugs = _context.Bugs.Find(id);
            if (bugs == null)
            {
                return NotFound();
            }

			_context.Bugs.Remove(bugs);
            _context.SaveChanges();
            return NoContent();
        }


		[HttpPost]
		public IActionResult Create([FromBody] Bug item)
        {
            var time = DateTime.UtcNow;
            if (item == null)
            {
                return BadRequest();
            }

            item.CreatedAtUTC = time;
            item.UpdatedAtUTC = time;

			_context.Bugs.Add(item);
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

			var bugs = _context.Bugs.Find(id);
            if (bugs == null)
            {
                return NotFound();
            }

            bugs.UpdatedAtUTC = DateTime.UtcNow;
			bugs.Name = item.Name;
			bugs.Description = item.Description;
            bugs.Assignee = item.Assignee;
            bugs.StoryPoints = item.StoryPoints;
            bugs.AcceptanceCriteria = item.AcceptanceCriteria;

			_context.Bugs.Update(bugs);
            _context.SaveChanges();
            return NoContent();
        }
    }
}