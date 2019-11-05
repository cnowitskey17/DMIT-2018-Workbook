namespace PraticeSystem.Entities
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using PraticeSystem.Entities;
    public partial class DemoContext : DbContext
    {
        public DemoContext()
            //Remember to change this to Default connection test writing me
            : base("name=DefaultConnection")
        {
        }

        public virtual DbSet<Staff> Staffs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Staff>()
                .Property(e => e.FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<Staff>()
                .Property(e => e.LastName)
                .IsUnicode(false);

            modelBuilder.Entity<Staff>()
                .Property(e => e.JobDescription)
                .IsUnicode(false);
        }
    }
}
