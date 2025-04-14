using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELearningPlatform.BLL.Dtos.CourseDtos
{
    public class CourseReadDto
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        //public string Category { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
