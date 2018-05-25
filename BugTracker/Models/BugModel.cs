using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BugTracker.Models
{
    public class Bug
    {
        [Key]
	    public long BugID { get; set; }

        [StringLength(50)]
        public string Name { get; set; }
        public string Description { get; set; }
        public string Assignee { get; set; }
        public int StoryPoints { get; set; }
        public enum State { toDo, inProggres, review, done }
        public long ProjectID { get; set; } 
    }
}
