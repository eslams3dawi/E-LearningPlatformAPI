using ELearningPlatform.BLL.Dtos.StudentDto;
using ELearningPlatform.BLL.Services.StudentService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ELearningPlatform.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        public readonly IStudentService IStudentService;
        public StudentController(IStudentService studentService)
        {
            IStudentService = studentService;
        }

        [HttpGet]
        public ActionResult GetStudents()
        {
            return Ok(IStudentService.GetStudents());
        }
        [HttpGet("{id}")]
        public ActionResult GetStudentById(int id)
        {
            return Ok(IStudentService.GetStudentById(id));
        }
        [HttpPost]
        public ActionResult AddStudent(StudentAddDto studentDto)
        {
            IStudentService.AddStudent(studentDto);
            return NoContent();
        }
        [HttpPut("{id}")]
        public ActionResult UpdateUser(int id, StudentUpdateDto studentDto)
        {
            if (id != studentDto.StudentId)
                return BadRequest();

            IStudentService.UpdateStudent(id, studentDto);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public ActionResult DeleteUser(int id)
        {
            IStudentService.DeleteStudent(id);
            return NoContent();
        }
    }
}
