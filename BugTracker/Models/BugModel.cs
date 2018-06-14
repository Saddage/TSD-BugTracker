﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public enum State { toDo, inProggres, readyToReview, done }
public enum Priority { low, medium, high }

namespace BugTracker.Models
{
	public class Bug
	{
		[Key]
		public long Id { get; set; }

		[StringLength(50)]
		public string Name { get; set; }
		public string Description { get; set; }
		public string Assignee { get; set; }
		public int StoryPoints { get; set; }
		public State state { get; set; }
		public Priority priority { get; set; }
        public string AcceptanceCriteria { get; set; }
        [Required, DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CreatedAtUTC { get; set; }
        public DateTime UpdatedAtUTC { get; set; }
    }
}