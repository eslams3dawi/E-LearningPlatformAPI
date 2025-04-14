using ELearningPlatform.BLL.Dtos.StudentDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELearningPlatform.BLL.Services.StudentService
{
    public interface IStudentService
    {
        void AddStudent(StudentAddDto studentAddDto);
        IEnumerable<StudentReadDto> GetStudents();
        StudentReadDto GetStudentById(int id);
        void UpdateStudent(int id, StudentUpdateDto studentUpdateDto);
        void DeleteStudent(int id);
    }
}
