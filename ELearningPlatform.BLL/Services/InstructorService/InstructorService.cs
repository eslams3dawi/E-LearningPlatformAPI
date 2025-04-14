using ELearningPlatform.BLL.Dtos.InstructorDto;
using ELearningPlatform.BLL.ExtensionMethods;
using ELearningPlatform.DAL.Models;
using ELearningPlatform.DAL.Repository.InstructorRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELearningPlatform.BLL.Services.InstructorService
{
    public class InstructorService : IInstructorService
    {
        private readonly IInstructorRepository _instructorRepository;
        public InstructorService(IInstructorRepository instructorRepository)
        {
            _instructorRepository = instructorRepository;
        }

        public void AddInstructor(InstructorAddDto instructorAddDto)
        {
            var instructorModel = new Instructor()
            {
                FirstName = instructorAddDto.FirstName,
                LastName = instructorAddDto.LastName,
                Age = instructorAddDto.Age,
                Specialization = instructorAddDto.Specialization,
                Salary = instructorAddDto.Salary,
                ExperienceYears = instructorAddDto.ExperienceYears
            };
            _instructorRepository.Add(instructorModel);
        }

        public void DeleteInstructor(int id)
        {
            var instructorModel = _instructorRepository.GetById(id);
            id.CheckForException<Instructor>(instructorModel);
            _instructorRepository.Delete(instructorModel);
        }

        public InstructorReadDto GetInstructorById(int id)
        {
            var instructorModel = _instructorRepository.GetById(id);
            id.CheckForException<Instructor>(instructorModel);
            var instructorDto = new InstructorReadDto()
            {
                InstructorId = instructorModel.InstructorId,
                FirstName = instructorModel.FirstName,
                LastName = instructorModel.LastName,
                Age = instructorModel.Age,
                Specialization = instructorModel.Specialization,
                Salary = instructorModel.Salary,
                ExperienceYears = instructorModel.ExperienceYears
            };
            return instructorDto;
        }

        public IEnumerable<InstructorReadDto> GetInstructors()
        {
            return _instructorRepository.Get().Select(i => new InstructorReadDto()
            {
                InstructorId = i.InstructorId,
                FirstName = i.FirstName,
                LastName = i.LastName,
                Age = i.Age,
                Specialization = i.Specialization,
                Salary = i.Salary,
                ExperienceYears = i.ExperienceYears
            });
        }

        public void UpdateInstructor(int id, InstructorUpdateDto instructorUpdateDto)
        {
            var instructorModel = _instructorRepository.GetById(id);
            id.CheckForException<Instructor>(instructorModel);

            instructorModel.FirstName = instructorUpdateDto.FirstName;
            instructorModel.LastName = instructorUpdateDto.LastName;
            instructorModel.Salary = instructorUpdateDto.Salary;
            instructorModel.ExperienceYears = instructorUpdateDto.ExperienceYears;

            _instructorRepository.Update(instructorModel);
        }
    }
}
