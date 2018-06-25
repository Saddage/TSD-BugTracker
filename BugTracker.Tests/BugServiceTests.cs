using BugTracker.Controllers;
using BugTracker.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace BugTracker.Tests
{
	public class BugTrackerControllerTest
	{
		[Fact]
		public void TestGetAllBugs()
		{
			var options = new DbContextOptionsBuilder<DatabaseContext>().UseInMemoryDatabase(databaseName: "TestGetAllBugs").Options;
			var context = new DatabaseContext(options);

			var bugs = Enumerable.Range(1, 10)
				 .Select(i => new Bug
				 {
					 Id = i,
					 Name = "Testowy",
					 AcceptanceCriteria = "criteria",
					 Assignee = "Milan Sawicki",
					 Description = "desc",
					 priority = Priority.high,
					 state = State.done,
					 StoryPoints = 5
				 });
			context.Bugs.AddRange(bugs);
			var bugController = new BugController(context);
			int c = context.SaveChanges();
			var result = bugController.GetAll();
			Assert.NotNull(result);
			Assert.Equal(10, result.Count);
		}

		[Fact]
		public void TestGetBugById()
		{
			var options = new DbContextOptionsBuilder<DatabaseContext>().UseInMemoryDatabase(databaseName: "TestGetBugById").Options;
			using (var context = new DatabaseContext(options))
			{
				var bugs = Enumerable.Range(1, 10)
					 .Select(i => new Bug
					 {
						 Id = i,
						 Name = "Testowy",
						 AcceptanceCriteria = "criteria",
						 Assignee = "Milan Sawicki",
						 Description = "desc",
						 priority = Priority.high,
						 state = State.done,
						 StoryPoints = 5
					 });
				context.Bugs.AddRange(bugs);
				var bugController = new BugController(context);
				int c = context.SaveChanges();
				var expectedId = 5;
				var actionResult = bugController.GetById(5);
				var okObjectResult = actionResult as OkObjectResult;
				Assert.NotNull(okObjectResult);
				var model = okObjectResult.Value as Models.Bug;
				Assert.NotNull(model);
				var actual = model.Id;
				Assert.Equal(expectedId, actual);
			}
		}

		[Fact]
		public void TestDeleteBugForId()
		{
			var options = new DbContextOptionsBuilder<DatabaseContext>().UseInMemoryDatabase(databaseName: "TestDeleteBugForId").Options;
			using (var context = new DatabaseContext(options))
			{
				var bugs = Enumerable.Range(1, 10)
					 .Select(i => new Bug
					 {
						 Id = i,
						 Name = "Testowy",
						 AcceptanceCriteria = "criteria",
						 Assignee = "Milan Sawicki",
						 Description = "desc",
						 priority = Priority.high,
						 state = State.done,
						 StoryPoints = 5
					 });
				context.Bugs.AddRange(bugs);
				var bugController = new BugController(context);
				int c = context.SaveChanges();
				var actionResult = bugController.Delete(5);
				var noContent = actionResult as NoContentResult;
				Assert.NotNull(noContent);
				Assert.Equal(204, noContent.StatusCode);
				var allBugs = bugController.GetAll();
				Assert.Equal(9, allBugs.Count);
			}
		}

		[Fact]
		public void TestCreateBug()
		{
			var options = new DbContextOptionsBuilder<DatabaseContext>().UseInMemoryDatabase(databaseName: "TestCreateBug").Options;
			using (var context = new DatabaseContext(options))
			{
				var bugs = new List<Bug>();
				context.Bugs.AddRange(bugs);
				var bugController = new BugController(context);
				int c = context.SaveChanges();
				var actionResult = bugController.Create(new Bug
				{
					Id = 666,
					Name = "Testowy",
					AcceptanceCriteria = "criteria",
					Assignee = "Milan Sawicki",
					Description = "desc",
					priority = Priority.high,
					state = State.done,
					StoryPoints = 5
				});
				var okObject = actionResult;
				Assert.NotNull(okObject);
				var createdAtRouteResult = actionResult as CreatedAtRouteResult;
				Assert.Equal(201, createdAtRouteResult.StatusCode);
				var allBugs = bugController.GetAll();
				Assert.Equal(1, allBugs.Count);
			}
		}

		[Fact]
        public void EmptyBugListTest()
        {
            var options = new DbContextOptionsBuilder<DatabaseContext>().UseInMemoryDatabase(databaseName: "EmptyList").Options;
            using (var context = new DatabaseContext(options))
            {
                var bugs = new List<Bug>();
                context.Bugs.AddRange(bugs);
                var bugController = new BugController(context);
                int c = context.SaveChanges();

				var result = bugController.GetAll();
				Assert.NotNull(result);
				Assert.Equal(0, result.Count);
            }
        }

		[Fact]
        public void TestUpdate()
        {
            var options = new DbContextOptionsBuilder<DatabaseContext>().UseInMemoryDatabase(databaseName: "TestGetAllBugs").Options;
            var context = new DatabaseContext(options);
            
            var bugController = new BugController(context);
            int c = context.SaveChanges();
			var result = bugController.Update(5, new Bug
            {
                Id = 666,
                Name = "Zmieniono",
                AcceptanceCriteria = "criteria",
                Assignee = "Milan Sawicki",
                Description = "desc",
                priority = Priority.high,
                state = State.done,
                StoryPoints = 5
            });
            Assert.NotNull(result);
			var noContent = result as NoContentResult;
			//Assert.Equal(204, noContent.StatusCode);
			Assert.Equal(10, context.Bugs.Count());
			var updatedObject = context.Bugs.Where(bug => bug.Id == 666);
			Assert.NotNull(updatedObject);         
        }
	}
}