using Datafication.Models.InputModels;
using Datafication.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Datafication.WebAPI.Controllers
{
    [ApiController]
    [Route("api/categories")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        [Route("{categoryId}")]
        public IActionResult GetIceCreamsByCategoryId(int categoryId)
            => Ok(_categoryService.GetIceCreamsByCategoryId(categoryId));

        [HttpPost]
        [Route("")]
        public IActionResult CreateNewCategory([FromBody] CategoryInputModel category)
        {
            _categoryService.CreateNewCategory(category);
            return new StatusCodeResult(201);
        }

        [HttpDelete]
        [Route("{categoryId}")]
        public IActionResult DeleteCategory(int categoryId)
        {
            _categoryService.DeleteCategory(categoryId);
            return NoContent();
        }
    }
}