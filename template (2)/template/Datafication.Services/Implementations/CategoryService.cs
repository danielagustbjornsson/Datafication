using System.Collections.Generic;
using Datafication.Models.Dtos;
using Datafication.Models.InputModels;
using Datafication.Repositories.Interfaces;
using Datafication.Services.Interfaces;

namespace Datafication.Services.Implementations
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public int CreateNewCategory(CategoryInputModel category)
            => _categoryRepository.CreateNewCategory(category);

        public void DeleteCategory(int id)
            => _categoryRepository.DeleteCategory(id);

        public IEnumerable<IceCreamDto> GetIceCreamsByCategoryId(int id)
            => _categoryRepository.GetIceCreamsByCategoryId(id);
    }
}