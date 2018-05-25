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
			return _context.bugs.ToList();
        }
  
		[HttpGet("/{projectId}/{bugId}", Name = "GetTask")]
        public IActionResult GetById(long projectId, long id)
        {
			var project = _context.projects.Find(projectId);
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
              
		[HttpPut("{id}")]
		public IActionResult Update(long id, [FromBody] Bug item)
        {
            if (item == null || item.BugID != id)
            {
                return BadRequest();
            }

			var bugs = _context.bugs.Find(id);
            if (bugs == null)
            {
                return NotFound();
            }

			bugs.Name = item.Name;
			bugs.Description = item.Description;

			_context.bugs.Update(bugs);
            _context.SaveChanges();
           
            return NoContent();
        }
    }
}
