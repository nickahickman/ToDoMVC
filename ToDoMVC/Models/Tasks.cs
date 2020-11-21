using System;
using System.Collections.Generic;

namespace ToDoMVC.Models
{
    public partial class Tasks
    {
        public int Id { get; set; }
        public string OwnerId { get; set; }
        public string Description { get; set; }
        public DateTime? DueDate { get; set; }
        public bool? IsComplete { get; set; }

        public virtual AspNetUsers Owner { get; set; }
    }
}
