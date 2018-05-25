using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BugTracker.Models
{
    public class User
    {
        [Key]
        public long UserID { get; set; }

        [StringLength(50)]
        public string Name { get; set; }
        public ICollection<Project> Projects { get; set; }
    }
}
