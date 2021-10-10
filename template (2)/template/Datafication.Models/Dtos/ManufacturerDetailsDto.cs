using System.Collections.Generic;

namespace Datafication.Models.Dtos
{
    public class ManufacturerDetailsDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Bio { get; set; }
        public string ExternalUrl { get; set; }
        public IEnumerable<IceCreamDto> IceCreams { get; set; }
        public int CategoryOccurrance { get; set; }
    }
}