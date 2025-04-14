using ELearningPlatform.BLL.Dtos.InstructorDto;
using ELearningPlatform.BLL.Dtos.StudentDto;
using ELearningPlatform.BLL.Services.InstructorService;
using ELearningPlatform.BLL.Services.StudentService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ELearningPlatform.API.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class InstructorsController : ControllerBase
    {
        public readonly IInstructorService _instructorService;
        public InstructorsController(IInstructorService instructorService)
        {
            _instructorService = instructorService;
        }

        [HttpGet]
        public ActionResult GetInstructors()
        {
            return Ok(_instructorService.GetInstructors());
        }

        [HttpGet("{id}")]
        public ActionResult GetInstructorById(int id)
        {
            return Ok(_instructorService.GetInstructorById(id));
        }

        [HttpPost]
        public ActionResult AddInstructor(InstructorAddDto instructorAddDto)
        {
            _instructorService.AddInstructor(instructorAddDto);
            return NoContent();
        }

        [HttpPut("{id}")]
        public ActionResult UpdateInstructor(int id, InstructorUpdateDto instructorUpdateDto)
        {
            if (id != instructorUpdateDto.InstructorId)
                return BadRequest();

            _instructorService.UpdateInstructor(id, instructorUpdateDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteUser(int id)
        {
            _instructorService.DeleteInstructor(id);
            return NoContent();
        }
    }
}
