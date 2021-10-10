using System.Collections.Generic;

namespace Datafication.Models.Dtos
{
    public class IceCreamDetailsDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IEnumerable<ImageDto> Images { get; set; }
        public ManufacturerDto Manufacturer { get; set; }
        public IEnumerable<CategoryDto> Categories { get; set; }
    }
}