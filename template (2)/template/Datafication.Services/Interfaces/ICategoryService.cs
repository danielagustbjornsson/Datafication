using System.Collections.Generic;
using Datafication.Models.Dtos;
using Datafication.Models.InputModels;

namespace Datafication.Services.Interfaces
{
    public interface ICategoryService
    {
         IEnumerable<IceCreamDto> GetIceCreamsByCategoryId(int id);
         int CreateNewCategory(CategoryInputModel category);
         void DeleteCategory(int id);
    }
}