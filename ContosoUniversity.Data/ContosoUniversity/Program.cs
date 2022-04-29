﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace  ContosoUniversity
{
    public class Program
    {
        static AppSettings appSettings = new AppSettings();
        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false);

            var configuration = builder.Build();
            ConfigurationBinder.Bind(configuration.GetSection("AppSettings"), appSettings);

            var schoolFactory = new SchoolContextFactory(appSettings.ConnectionString);
            var blankParams = new string[] { };
            var schoolContext = schoolFactory.CreateDbContext(blankParams);
            CreateDbIfNotExists(schoolContext);

            // Return IQueryable using Methods
            var seth = schoolContext.Students.Where(s => s.FirstMidName.StartsWith("S")).ToList();

            // Return IQueryable using Query
            var seth2 = from student in schoolContext.Students
                        where student.FirstMidName == "Seth"
                        select student;

            //IQueryable IEnumerable
            // Return related data from many to many in Query
            var sethsCourses = from course in schoolContext.Courses
                               join enrollment in schoolContext.Enrollments
                               on course.Id equals enrollment.CourseId
                               join student in schoolContext.Students
                               on enrollment.StudentId equals student.Id
                               where student.FirstMidName == "Seth"
                               select course;
            
            //Console.WriteLine(sethsCourses.First());

            // Return related data from many to many in Method
            var sethsCourses2 = schoolContext.Enrollments
                .Include(e => e.Student)
                .Include(e => e.Course)
                .Where(e => e.Student.FirstMidName == "Seth")
                .Select(e => e.Course)
                .ToList();


            var myEnrollments = schoolContext.Enrollments
                .Include(e => e.Student)
                .Include(e => e.Course)
                .Where(e => e.StudentId == 1)
                .ToList();

            //foreach (var en in myEnrollments)
            //{
            //    schoolContext.Remove(en);
            //}


            //schoolContext.RemoveRange(myEnrollments);
            
            var me = schoolContext.Students.First(s => s.Id == 1);
            me.FirstMidName = "Seth";

            //schoolContext.Update(me);

            schoolContext.SaveChanges();

            
        }

        private static void CreateDbIfNotExists(SchoolContext ctx)
        {
            try
            {
                //ctx.Database.EnsureDeleted();
                DbInitializer.Initialize(ctx);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"An Error Occurred: {ex.Message}");
            }
        }

    }
}
