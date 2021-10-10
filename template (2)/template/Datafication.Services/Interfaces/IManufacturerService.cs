using Datafication.Models.Dtos;

namespace Datafication.Services.Interfaces
{
    public interface IManufacturerService
    {
         ManufacturerDetailsDto GetManufacturerById(int id);
    }
}