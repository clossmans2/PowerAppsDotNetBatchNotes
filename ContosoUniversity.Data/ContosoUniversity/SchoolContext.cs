using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ContosoUniversity
{
    public class SchoolContext : DbContext
    {
        public SchoolContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Enrollment>()
                .HasMany<Course>();

            modelBuilder.Entity<Enrollment>()
                .HasOne<Student>()
                .WithMany(s => s.Enrollments)
                .HasForeignKey(e => e.StudentId);
                

            modelBuilder.Entity<Student>()
                .HasMany<Enrollment>();

            modelBuilder.Entity<Course>()
                .HasMany<Enrollment>();

            modelBuilder.Entity<Student>()
                .Property("EnrollmentDate")
                .HasDefaultValue(DateTime.Now);

            

            // One to one relationship
            //modelBuilder.Entity<Student>()
            //    .HasOne<Enrollment>()
            //    .WithOne("Student");

        }

        public DbSet<Course> Courses { get; set; } = null!;
        public DbSet<Enrollment> Enrollments { get; set; } = null!;
        public DbSet<Student> Students { get; set; } = null!;
    }

    public class SchoolContextFactory : IDesignTimeDbContextFactory<SchoolContext>
    {
        private readonly string _connectionString;

        public SchoolContextFactory()
        {
            _connectionString = "Data Source=0250L-D6YGCL2;Initial Catalog=ContosoUniversity;Trusted_Connection=True;";
        }

        public SchoolContextFactory(string connectionString)
        {
            _connectionString = connectionString;
        }

        public SchoolContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<SchoolContext>();
            optionsBuilder.UseSqlServer(_connectionString);
            return new SchoolContext(optionsBuilder.Options);
        }
    }

}
