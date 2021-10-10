using Datafication.Models.Dtos;

namespace Datafication.Repositories.Interfaces
{
    public interface IManufacturerRepository
    {
        ManufacturerDetailsDto GetManufacturerById(int id);
    }
}