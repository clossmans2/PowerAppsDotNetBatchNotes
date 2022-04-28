using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContosoUniversity
{
    public enum Grade
    {
        A,
        B,
        C,
        D,
        F
    }

    public class Enrollment
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public int StudentId { get; set; }
        
        [DisplayFormat(NullDisplayText = "No grade")]
        public Grade? Grade { get; set; }


        public Course Course { get; set; } = null!;
        public Student Student { get; set; } = null!;
    }
}
