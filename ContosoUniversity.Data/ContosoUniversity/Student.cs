using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContosoUniversity
{
    [Table("Student")]
    public class Student
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "First Name")]


        public string FirstMidName { get; set; } = null!;
        [MaxLength(150, ErrorMessage = "Your Name Is Too Long!")]
        [MinLength(2)]
        public string LastName { get; set; } = null!;
        [Required]
        [Column("DateOfEnrollment")]
        public DateTime EnrollmentDate { get; set; } = DateTime.Now;

        public ICollection<Enrollment> Enrollments { get; set; } = null!;

        [NotMapped]
        public string FullName
        {
            get
            {
                return $"{FirstMidName} {LastName}";
            }
        }
    }
}
