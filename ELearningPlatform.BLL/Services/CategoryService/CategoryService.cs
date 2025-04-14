using ELearningPlatform.BLL.Dtos.CategoryDtos;
using ELearningPlatform.BLL.Dtos.StudentDto;
using ELearningPlatform.BLL.ExtensionMethods;
using ELearningPlatform.DAL.Models;
using ELearningPlatform.DAL.Repository.CategoryRepository;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELearningPlatform.BLL.Services.CategoryService
{
    public class CategoryService : ICategoryService
    {
        private const string _Cache_Key = "Cache_Category";
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMemoryCache _memoryCache;

        public CategoryService(ICategoryRepository categoryRepository, IMemoryCache memoryCache)
        {
            _categoryRepository = categoryRepository;
            _memoryCache = memoryCache;
        }

        public void AddCategory(CategoryAddDto categoryAddDto)//There is will be cache in insert
        {
            var categoryModel = new Category()
            {
                CategoryName = categoryAddDto.CategoryName
            };
            _categoryRepository.Add(categoryModel);
        }
        public IEnumerable<CategoryReadDto> GetCategories()
        {
            //Key is the reference (must be unique)
            if(!_memoryCache.TryGetValue(_Cache_Key, out IEnumerable<CategoryReadDto> categoryDtos))
            {
                var categoryModels = _categoryRepository.Get();

                categoryDtos = categoryModels.Select(c => new CategoryReadDto()
                {
                    CategoryId = c.CategoryId,
                    CategoryName = c.CategoryName
                }).ToList();

                MemoryCacheEntryOptions options = new MemoryCacheEntryOptions()
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromDays(15)
                };   

                _memoryCache.Set(_Cache_Key, categoryDtos, options);
            }
            return categoryDtos;
        }

        public CategoryReadDto GetCategoryById(int id)
        {
            if(!_memoryCache.TryGetValue($"{_Cache_Key}_{id}", out CategoryReadDto categoryDto))
            {
                var categoryModel = _categoryRepository.GetById(id);
                id.CheckForException<Category>(categoryModel);

                categoryDto = new CategoryReadDto()
                {
                    CategoryId = categoryModel.CategoryId,
                    CategoryName = categoryModel.CategoryName
                };

                MemoryCacheEntryOptions options = new MemoryCacheEntryOptions()
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(15)
                };
                _memoryCache.Set(_Cache_Key, categoryDto, options);
            }

            return categoryDto;
        }

        public void UpdateCategory(int id, CategoryUpdateDto categoryUpdateDto)
        {
            var categoryModel = _categoryRepository.GetById(id);
            id.CheckForException<Category>(categoryModel);

            categoryModel.CategoryName = categoryUpdateDto.CategoryName;

            _categoryRepository.Update(categoryModel);

            RemoveFromCache(id);
        }

        public void DeleteCategory(int id)
        {
            var categoryModel = _categoryRepository.GetById(id);
            id.CheckForException<Category>(categoryModel);

            _categoryRepository.Delete(categoryModel);

            RemoveFromCache(id);
        }
        private void RemoveFromCache(int id)
        {
            //if this modified object is cached,
            //will remove it from cache to get the last updated version from the database
            if (_memoryCache.TryGetValue($"{_Cache_Key}_{id}", out _))//out _ : means you want to discard this parameter in this case
                _memoryCache.Remove($"{_Cache_Key}_{id}");
            //will check if the object is cached, will remove it
            //Otherwise, will not do anything

            //if the object within list of objects, then will have to remove this cached list
            if (_memoryCache.TryGetValue(_Cache_Key, out IEnumerable<CategoryReadDto> categoryDtos))
                if (categoryDtos.Any(c => c.CategoryId == id))
                    _memoryCache.Remove(_Cache_Key);
        }
    }
}
