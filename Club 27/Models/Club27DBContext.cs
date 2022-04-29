using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Club_27.Models
{
    public class Club27DBContext : IdentityDbContext
    {
        public Club27DBContext(DbContextOptions<Club27DBContext> options) : base(options)
        {

        }
        protected override void OnModelCreating (ModelBuilder modelBuilder)
        { 
            base.OnModelCreating(modelBuilder);

            //Adding Unique Constraint
            modelBuilder.Entity<Enrollment>().HasIndex(x => new { x.EmployeeID, x.ActivityID }).IsUnique(true);
            modelBuilder.Entity<EmployeeMaster>().HasIndex(x => new { x.Email }).IsUnique(true);
            modelBuilder.Entity<ActivityMaster>().HasIndex(x => new { x.ActivityName }).IsUnique(true);

            //modelBuilder.Entity<ActivityMaster>().WillCascadeOnDelete(false);

            //modelBuilder.Entity<Enrollment>(entity => {
            //    entity.HasIndex(e => new{ e.EmployeeID,e.ActivityID}).IsUnique();
            //});

        }

        public DbSet<ActivityMaster> ActivityMasters { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<EmployeeMaster> EmployeeMasters { get; set; }
        //public DbSet<User> Users { get; set; }
        public DbSet<Venue> Venues { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        //public DbSet<Role> Roles { get; set; }

    }
}
