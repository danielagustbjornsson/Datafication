using System.Collections.Generic;
using Datafication.Models.Dtos;
using Datafication.Models.InputModels;
using Datafication.Repositories.Interfaces;
using Datafication.Services.Interfaces;

namespace Datafication.Services.Implementations
{
    public class IceCreamService : IIceCreamService
    {
        private readonly IIceCreamRepository _iceCreamRepository;

        public IceCreamService(IIceCreamRepository iceCreamRepository)
        {
            _iceCreamRepository = iceCreamRepository;
        }

        public void AddIceCreamToCategory(int iceCreamId, int categoryId)
            => _iceCreamRepository.AddIceCreamToCategory(iceCreamId, categoryId);

        public int CreateNewIceCream(IceCreamInputModel iceCream)
            => _iceCreamRepository.CreateNewIceCream(iceCream);

        public void DeleteIceCream(int id)
            => _iceCreamRepository.DeleteIceCream(id);

        public IEnumerable<IceCreamDto> GetAllIceCreams()
            => _iceCreamRepository.GetAllIceCreams();

        public IceCreamDetailsDto GetIceCreamById(int id)
            => _iceCreamRepository.GetIceCreamById(id);

        public void UpdateIceCream(int id, IceCreamInputModel iceCream)
            => _iceCreamRepository.UpdateIceCream(id, iceCream);
    }
}