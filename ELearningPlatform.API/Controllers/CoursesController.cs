using ELearningPlatform.BLL.Dtos.CourseDtos;
using ELearningPlatform.BLL.Dtos.InstructorDto;
using ELearningPlatform.BLL.Services.CourseService;
using ELearningPlatform.BLL.Services.InstructorService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ELearningPlatform.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        public readonly ICourseService _courseService;
        public CoursesController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpGet]
        public ActionResult GetCourses()
        {
            return Ok(_courseService.GetCourses());
        }

        [HttpGet("{id}")]
        public ActionResult GetCourseById(int id)
        {
            return Ok(_courseService.GetCourseById(id));
        }

        [HttpPost]
        public ActionResult AddCourse(CourseAddDto courseAddDto)
        {
            _courseService.AddCourse(courseAddDto);
            return NoContent();
        }

        [HttpPut("{id}")]
        public ActionResult UpdateCourse(int id, CourseUpdateDto courseUpdateDto)
        {
            if (id != courseUpdateDto.CourseId)
                return BadRequest();

            _courseService.UpdateCourse(id, courseUpdateDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteCourse(int id)
        {
            _courseService.DeleteCourse(id);
            return NoContent();
        }
    }
}
