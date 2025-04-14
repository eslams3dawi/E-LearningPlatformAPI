using ELearningPlatform.BLL.Dtos.CourseDtos;
using ELearningPlatform.BLL.Dtos.StudentDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELearningPlatform.BLL.Services.CourseService
{
    public interface ICourseService
    {
        void AddCourse(CourseAddDto courseAddDto);
        IEnumerable<CourseReadDto> GetCourses();
        CourseReadDto GetCourseById(int id);
        void UpdateCourse(int id, CourseUpdateDto courseUpdateDto);
        void DeleteCourse(int id);
    }
}
