using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContosoUniversity
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstMidName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public DateTime EnrollmentDate { get; set; } = DateTime.Now;

        public ICollection<Enrollment> Enrollments { get; set; } = null!;
    }
}
