using System.Collections.Generic;
using Datafication.Models.Dtos;
using Datafication.Models.InputModels;

namespace Datafication.Repositories.Interfaces
{
    public interface IIceCreamRepository
    {
        IEnumerable<IceCreamDto> GetAllIceCreams();
        IceCreamDetailsDto GetIceCreamById(int id);
        int CreateNewIceCream(IceCreamInputModel iceCream);
        void UpdateIceCream(int id, IceCreamInputModel iceCream);
        void DeleteIceCream(int id);
        void AddIceCreamToCategory(int iceCreamId, int categoryId);
    }
}