using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lab_47_to_do_app.Models
{
    public class ToDoDbContext : DbContext
    {
        public DbSet<ToDo> ToDos { get; set; }
        public DbSet<User> Users { get; set; }
        public ToDoDbContext() { }
        public ToDoDbContext(DbContextOptions<ToDoDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Relationships
            builder.Entity<User>()
                .HasMany(user => user.ToDos)
                .WithOne(user => user.User);

            // Username is require
            builder.Entity<User>()
                .Property(user => user.UserName)
                .IsRequired();

            // Seed Data
            builder.Entity<User>().HasData(
                new User { UserId = 1, UserName = "John"},
                new User { UserId = 2, UserName = "Jane" },
                new User { UserId = 3, UserName = "Alice" }
            );

            builder.Entity<ToDo>().HasData(
                new ToDo { ToDoId = 1, ToDoName = "Coding", UserId = 1 },
                new ToDo { ToDoId = 2, ToDoName = "Quality Gate Revise", UserId = 2 },
                new ToDo { ToDoId = 3, ToDoName = "Group Project", UserId = 3 }
                );
        }

    }
}
