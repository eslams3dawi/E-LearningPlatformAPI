
using ELearningPlatform.BLL.Dtos.CourseDtos;
using ELearningPlatform.BLL.Dtos.StudentDto;
using ELearningPlatform.BLL.ExtensionMethods;
using ELearningPlatform.DAL.Models;
using ELearningPlatform.DAL.Repository.CourseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELearningPlatform.BLL.Services.CourseService
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;
        public CourseService(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }
        public void AddCourse(CourseAddDto courseAddDto)
        {
            var courseModel = new Course()
            {
                CourseName = courseAddDto.CourseName,
            };
            _courseRepository.Add(courseModel);
        }

        public void DeleteCourse(int id)
        {
            var courseModel = _courseRepository.GetById(id);
            id.CheckForException<Course>(courseModel);
            _courseRepository.Delete(courseModel);
        }

        public CourseReadDto GetCourseById(int id)
        {
            var courseModel = _courseRepository.GetById(id);
            id.CheckForException<Course>(courseModel);
            var courseDto = new CourseReadDto()
            {
                CourseId = courseModel.CourseId,
                CourseName = courseModel.CourseName,
                CreationDate = courseModel.CreationDate
            };
            return courseDto;
        }

        public IEnumerable<CourseReadDto> GetCourses()
        {
            return _courseRepository.Get().Select(c => new CourseReadDto()
            {
                CourseId = c.CourseId,
                CourseName = c.CourseName,
                CreationDate = c.CreationDate
            });
        }

        public void UpdateCourse(int id, CourseUpdateDto courseUpdateDto)
        {
            var courseModel = _courseRepository.GetById(id);
            id.CheckForException<Course>(courseModel);
            courseModel.CourseName = courseUpdateDto.CourseName;

            _courseRepository.Update(courseModel);
        }
    }
}
