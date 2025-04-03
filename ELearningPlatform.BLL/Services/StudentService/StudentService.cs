using ELearningPlatform.BLL.Dtos.StudentDto;
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

        public void AddStudent(StudentAddDto studentDto)
        {
            var studentModel = new Student()
            {
                FirstName = studentDto.FirstName,
                LastName = studentDto.LastName,
                Age = studentDto.Age,
                Gender = studentDto.Gender,
                EnrollmentDate = DateTime.UtcNow
            };
            _studentRepository.Add(studentModel);
        }

        public void DeleteStudent(int id)
        {
            var studentModel = _studentRepository.GetById(id);
            _studentRepository.Delete(studentModel);
        }

        public StudentReadDto GetStudentById(int id)
        {
            var studentModel = _studentRepository.GetById(id);

            var studentDto = new StudentReadDto()
            {
                StudentId = studentModel.StudentId,
                FirstName = studentModel.FirstName,
                LastName = studentModel.LastName,
                Age = studentModel.Age,
                Gender = studentModel.Gender
            };
            return studentDto;
        }

        public IQueryable<StudentReadDto> GetStudents()
        {
            return _studentRepository.Get().Select(s => new StudentReadDto()
            {
                StudentId = s.StudentId,
                FirstName = s.FirstName,
                LastName = s.LastName,
                Age = s.Age,
                Gender = s.Gender
            });
        }

        public void UpdateStudent(int id, StudentUpdateDto studentDto)
        {
            var studentModel = _studentRepository.GetById(id);

            studentModel.FirstName = studentDto.FirstName;
            studentModel.LastName = studentDto.LastName;
            studentModel.Age = studentDto.Age;
            studentModel.Gender = studentDto.Gender;

            _studentRepository.Update(studentModel);
        }
    }
}
