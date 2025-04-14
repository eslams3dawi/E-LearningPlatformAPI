using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELearningPlatform.BLL.Dtos.InstructorDto
{
    public class InstructorAddDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public decimal Salary { get; set; }
        public string Specialization { get; set; }
        public int ExperienceYears { get; set; }
    }
}
