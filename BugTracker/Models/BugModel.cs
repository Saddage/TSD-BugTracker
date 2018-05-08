using System;
using System.ComponentModel.DataAnnotations;

namespace BugTracker.Models
{
    public class Bug
    {
	    public long Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
