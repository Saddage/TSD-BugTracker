using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BugTracker.Models;

namespace BugTracker.Controllers
{
	[Route("api/[controller]")]
	public class ProjectController : ControllerBase
	{
		private readonly DatabaseContext _context;

		public ProjectController(DatabaseContext context)
		{
			_context = context;
		}

		[HttpGet]
		public List<Project> GetAll()
		{
			return _context.projects.ToList();
		}

		[HttpGet("{id}", Name = "getProject")]
		public IActionResult GetProjectById(long id)
		{
			var item = _context.projects.Find(id);
			if (item == null)
			{
				return NotFound();
			}
			return Ok(item);
		}

		[HttpDelete("{id}")]
		public IActionResult Delete(long id)
		{
			var projects = _context.projects.Find(id);
			if (projects == null)
			{
				return NotFound();
			}

			_context.projects.Remove(projects);
			_context.SaveChanges();
			return NoContent();
		}


		[HttpPost]
		public IActionResult Create([FromBody] Project item)
		{
			if (item == null)
			{
				return BadRequest();
			}
			item.Bugs = new List<Bug>();
			_context.projects.Add(item);
			_context.SaveChanges();

			return CreatedAtRoute("GetProject", new { id = item.ProjectID }, item);
		}

		[HttpPost("{id}/tasks")]
		public IActionResult CreateBug(long id, [FromBody] Bug item)
		{
			if (item == null)
			{
				return BadRequest();
			}
			var project = _context.projects.Find(id);
			_context.bugs.Add(item);
			_context.SaveChanges();

			return Created("{id}/tasks", item);
		}

		[HttpPut("{id}")]
		public IActionResult Update(long id, [FromBody] Project item)
		{
			if (item == null || item.ProjectID != id)
			{
				return BadRequest();
			}

			var projects = _context.projects.Find(id);
			if (projects == null)
			{
				return NotFound();
			}

			projects.Name = item.Name;
			projects.Description = item.Description;

			_context.projects.Update(projects);
			_context.SaveChanges();
			return NoContent();
		}

		[HttpGet("tasks/{id}", Name = "getTaskForProject")]
		public IActionResult GetTaskById(long id)
		{
			var item = _context.projects.Find(id);
			var bugs = _context.bugs.ToList();
			if (item == null) {
				return NotFound();
			}
			return Ok(item.Bugs);
		}
	}
}