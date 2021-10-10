using Datafication.Models.Dtos;
using Datafication.Repositories.Interfaces;
using Datafication.Services.Interfaces;

namespace Datafication.Services.Implementations
{
    public class ManufacturerService : IManufacturerService
    {
        private readonly IManufacturerRepository _manufacturerRepository;

        public ManufacturerService(IManufacturerRepository manufacturerRepository)
        {
            _manufacturerRepository = manufacturerRepository;
        }

        public ManufacturerDetailsDto GetManufacturerById(int id)
            => _manufacturerRepository.GetManufacturerById(id);
    }
}