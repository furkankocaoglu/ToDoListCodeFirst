using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace ToDoListMVC.Models
{
    public partial class ToDoListDB : DbContext
    {
        public ToDoListDB()
            : base("name=ToDoListDB")
        {
        }

        public DbSet <Work> Works { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
