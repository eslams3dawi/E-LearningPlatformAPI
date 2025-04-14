using ELearningPlatform.BLL.Dtos.CategoryDtos;
using ELearningPlatform.BLL.Dtos.StudentDto;
using ELearningPlatform.BLL.Services.CategoryService;
using ELearningPlatform.BLL.Services.StudentService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ELearningPlatform.API.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        public readonly ICategoryService _categoryService;
        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public ActionResult GetCategories()
        {
            return Ok(_categoryService.GetCategories());
        }

        [HttpGet("{id}")]
        public ActionResult GetCategoryById(int id)
        {
            return Ok(_categoryService.GetCategoryById(id));
        }

        [HttpPost]
        public ActionResult AddCategory(CategoryAddDto categoryAddDto)
        {
            _categoryService.AddCategory(categoryAddDto);
            return NoContent();
        }

        [HttpPut("{id}")]
        public ActionResult UpdateCategory(int id, CategoryUpdateDto categoryUpdateDto)
        {
            if (id != categoryUpdateDto.CategoryId)
                return BadRequest();

            _categoryService.UpdateCategory(id, categoryUpdateDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteCategory(int id)
        {
            _categoryService.DeleteCategory(id);
            return NoContent();
        }
    }
}
