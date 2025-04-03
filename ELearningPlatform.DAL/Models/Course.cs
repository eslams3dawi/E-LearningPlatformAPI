using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELearningPlatform.DAL.Models
{
    public class Course
    {
        public string CourseId { get; set; }
        public string CourseName { get; set; }
        public string Category { get; set; }
        public DateTime CreationDate { get; set; }

        public ICollection<Student> Students { get; set; }

        public int? InstructorId { get; set; }
        public Instructor Instructor { get; set; }
    }
}
