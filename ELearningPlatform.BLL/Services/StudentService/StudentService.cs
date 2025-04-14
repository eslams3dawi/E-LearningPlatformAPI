using ELearningPlatform.BLL.Dtos.StudentDto;
using ELearningPlatform.BLL.ExtensionMethods;
using ELearningPlatform.DAL.Models;
using ELearningPlatform.DAL.Repository.StudentRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELearningPlatform.BLL.Services.StudentService
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public void AddStudent(StudentAddDto studentAddDto)
        {
            var studentModel = new Student()
            {
                FirstName = studentAddDto.FirstName,
                LastName = studentAddDto.LastName,
                Age = studentAddDto.Age,
                Gender = studentAddDto.Gender,
                EnrollmentDate = DateTime.UtcNow
            };
            _studentRepository.Add(studentModel);
        }

        public void DeleteStudent(int id)
        {
            var studentModel = _studentRepository.GetById(id);
            id.CheckForException<Student>(studentModel);
            _studentRepository.Delete(studentModel);
        }

        public StudentReadDto GetStudentById(int id)
        {
            var studentModel = _studentRepository.GetById(id);
            id.CheckForException<Student>(studentModel);
            var studentDto = new StudentReadDto()
            {
                StudentId = studentModel.StudentId,
                FirstName = studentModel.FirstName,
                LastName = studentModel.LastName,
                Age = studentModel.Age,
                Gender = studentModel.Gender,
                EnrollmentDate = studentModel.EnrollmentDate
            };
            return studentDto;
        }

        public IEnumerable<StudentReadDto> GetStudents()
        {
            return _studentRepository.Get().Select(s => new StudentReadDto()
            {
                StudentId = s.StudentId,
                FirstName = s.FirstName,
                LastName = s.LastName,
                Age = s.Age,
                Gender = s.Gender,
                EnrollmentDate = s.EnrollmentDate
            });
        }

        public void UpdateStudent(int id, StudentUpdateDto studentUpdateDto)
        {
            var studentModel = _studentRepository.GetById(id);
            id.CheckForException<Student>(studentModel);
            studentModel.FirstName = studentUpdateDto.FirstName;
            studentModel.LastName = studentUpdateDto.LastName;
            studentModel.Age = studentUpdateDto.Age;
            studentModel.Gender = studentUpdateDto.Gender;

            _studentRepository.Update(studentModel);
        }
    }
}
