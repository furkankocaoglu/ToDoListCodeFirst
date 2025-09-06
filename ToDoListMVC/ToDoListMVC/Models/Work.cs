using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ToDoListMVC.Models
{
    public class Work
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Bu alan boş geçilemez")]
        public string Title { get; set; }

        public bool IsCompleted { get; set; }

        public bool Deleted { get; set; }

        public DateTime Created { get; set; } = DateTime.Now;
    }
}