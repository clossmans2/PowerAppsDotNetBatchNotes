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
        private readonly string _connectionString;

        public SchoolContext(string connectionString)
        {
            _connectionString = connectionString;
        }


        public SchoolContext(DbContextOptions<SchoolContext> options) : base (options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Student> Students { get; set; }
    }

    public class SchoolContextFactory : IDesignTimeDbContextFactory<SchoolContext>
    {
        private readonly string _connectionString;

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
