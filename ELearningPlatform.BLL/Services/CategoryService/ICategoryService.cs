using ELearningPlatform.BLL.Dtos.CategoryDtos;
using ELearningPlatform.BLL.Dtos.StudentDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELearningPlatform.BLL.Services.CategoryService
{
    public interface ICategoryService
    {
        void AddCategory(CategoryAddDto categoryAddDto);
        IEnumerable<CategoryReadDto> GetCategories();
        CategoryReadDto GetCategoryById(int id);
        void UpdateCategory(int id, CategoryUpdateDto categoryUpdateDto);
        void DeleteCategory(int id);
    }
}
