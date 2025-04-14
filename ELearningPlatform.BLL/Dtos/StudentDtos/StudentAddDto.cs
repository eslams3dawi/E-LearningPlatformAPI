using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELearningPlatform.BLL.Dtos.StudentDto
{
    public class StudentAddDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Range(6, 100, ErrorMessage = "Age must be at least 6 years")]
        public int Age { get; set; }
        public string Gender { get; set; }
    }
}
