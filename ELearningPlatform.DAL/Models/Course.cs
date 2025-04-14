using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELearningPlatform.DAL.Models
{
    public class Course
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.UtcNow;

        public ICollection<Student> Students { get; set; }

        public int? InstructorId { get; set; }
        public Instructor Instructor { get; set; }

        public int? CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
