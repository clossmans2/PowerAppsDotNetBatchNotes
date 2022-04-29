using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContosoUniversity
{
    public static class DbInitializer
    {
        public static void Initialize(SchoolContext context)
        {
            context.Database.EnsureCreated();

            if (!context.Students.Any())
            {
                var students = new Student[]
                {
                    new Student{FirstMidName = "Seth", LastName = "Clossman"},
                    new Student{FirstMidName="Carson",LastName="Alexander"},
                    new Student{FirstMidName="Meredith",LastName="Alonso"},
                    new Student{FirstMidName="Arturo",LastName="Anand"},
                    new Student{FirstMidName="Gytis",LastName="Barzdukas"},
                    new Student{FirstMidName="Yan",LastName="Li"},
                    new Student{FirstMidName="Peggy",LastName="Justice"},
                    new Student{FirstMidName="Laura",LastName="Norman"},
                    new Student{FirstMidName="Nino",LastName="Olivetto"}
                };

                foreach (Student stud in students)
                {
                    context.Students.Add(stud);
                }

                context.SaveChanges();
            }

            if (!context.Courses.Any())
            {
                var courses = new Course[]
                {
                    new Course{Id=1,Title ="Chemistry",Credits = 3},
                    new Course{Id=2,Title="Literature",Credits=4},
                    new Course{Id=3,Title="Microeconomics",Credits=3},
                    new Course{Id=4,Title="Macroeconomics",Credits=3},
                    new Course{Id=5,Title="Calculus",Credits=4},
                    new Course{Id=6,Title="Underwater Basket Weaving",Credits=1}
                };

                foreach (Course c in courses)
                {
                    context.Courses.Add(c);
                }

                context.SaveChanges();
            }

            if (!context.Enrollments.Any())
            {
                var enrollments = new Enrollment[]
                {
                    new Enrollment{StudentId=1,CourseId=1,Grade=Grade.A},
                    new Enrollment{StudentId=1,CourseId=4,Grade=Grade.C},
                    new Enrollment{StudentId=1,CourseId=4,Grade=Grade.B},
                    new Enrollment{StudentId=2,CourseId=1,Grade=Grade.B},
                    new Enrollment{StudentId=2,CourseId=3,Grade=Grade.F},
                    new Enrollment{StudentId=2,CourseId=2,Grade=Grade.F},
                    new Enrollment{StudentId=3,CourseId=1},
                    new Enrollment{StudentId=4,CourseId=1},
                    new Enrollment{StudentId=4,CourseId=4,Grade=Grade.F},
                    new Enrollment{StudentId=5,CourseId=4,Grade=Grade.C},
                    new Enrollment{StudentId=6,CourseId=1},
                    new Enrollment{StudentId=7,CourseId=3,Grade=Grade.A},

                };

                foreach (Enrollment e in enrollments)
                {
                    context.Enrollments.Add(e);
                }

                context.SaveChanges();
            }            

        }
    }
}
