using ELearningPlatform.API.Filters;
using ELearningPlatform.BLL.Dtos.StudentDto;
using ELearningPlatform.BLL.Services.StudentService;
using ELearningPlatform.DAL.Repository.StudentRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ELearningPlatform.API.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        public readonly IStudentService _studentService;

        public StudentsController(IStudentService studentService)
        {
            _studentService = studentService;
        }
        [HttpGet]
        public ActionResult GetStudents()
        {
            return Ok(_studentService.GetStudents());
        }

        //[ProducesResponseType(typeof(StudentReadDto), StatusCodes.Status200OK)]
        [HttpGet("{id}")]
        public ActionResult GetStudentById(int id)
        {
            var model = _studentService.GetStudentById(id);
            return Ok(model);
        }

        [HttpPost]
        //[CheckAgeIfLessThan6]//Without Attribute Keyword
        public ActionResult AddStudent(StudentAddDto studentAddDto)
        {
            //Executing
            _studentService.AddStudent(studentAddDto);
            return NoContent();
            //Executed
        }

        [HttpPut("{id}")]
        public ActionResult UpdateStudent(int id, StudentUpdateDto studentUpdateDto)
        {
            if (id != studentUpdateDto.StudentId)
                return BadRequest();

            _studentService.UpdateStudent(id, studentUpdateDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteStudent(int id)
        {
            _studentService.DeleteStudent(id);
            return NoContent();
        }
    }
}
