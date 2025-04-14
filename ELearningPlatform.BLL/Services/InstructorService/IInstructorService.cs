using ELearningPlatform.BLL.Dtos.InstructorDto;
using ELearningPlatform.DAL.Repository.InstructorRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELearningPlatform.BLL.Services.InstructorService
{
    public interface IInstructorService
    {
        public void AddInstructor(InstructorAddDto instructorAddDto);
        public IEnumerable<InstructorReadDto> GetInstructors();
        public InstructorReadDto GetInstructorById(int id);
        public void DeleteInstructor(int id);
        public void UpdateInstructor(int id, InstructorUpdateDto instructorUpdateDto);
    }
}
