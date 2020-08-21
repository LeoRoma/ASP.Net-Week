using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using lab_46_asp_core_mvc.Models;

namespace lab_46_asp_core_mvc.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<lab_46_asp_core_mvc.Models.College> College { get; set; }
        public DbSet<lab_46_asp_core_mvc.Models.Student> Student { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<College>()
                .HasKey(college => college.CollegeId);

            builder.Entity<College>()
                .Property(college => college.CollegeName)
                .IsRequired();
        }
    }
}
