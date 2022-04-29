using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContosoUniversity
{
    public class Course
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public int Credits { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; } = null!;
    }
}
