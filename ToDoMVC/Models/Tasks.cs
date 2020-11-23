using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ToDoMVC.Models
{
    public partial class Tasks
    {
        
        public int Id { get; set; }
        public string OwnerId { get; set; }
        [Required]
        [StringLength(255, ErrorMessage = "Maximum Description Length is 255 characters")]
        public string Description { get; set; }
        [Required]
        public DateTime? DueDate { get; set; }
        public bool? IsComplete { get; set; }

        public virtual AspNetUsers Owner { get; set; }
    }
}
