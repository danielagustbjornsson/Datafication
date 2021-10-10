using System.Collections.Generic;
using Datafication.Models.Dtos;
using Datafication.Models.InputModels;

namespace Datafication.Repositories.Interfaces
{
    public interface ICategoryRepository
    {
         IEnumerable<IceCreamDto> GetIceCreamsByCategoryId(int id);
         int CreateNewCategory(CategoryInputModel category);
         void DeleteCategory(int id);
    }
}