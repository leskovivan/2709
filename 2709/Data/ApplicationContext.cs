using _2709.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace _2709.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        public DbSet<ToDoTask> Tasks { get; set; }
    }

}
