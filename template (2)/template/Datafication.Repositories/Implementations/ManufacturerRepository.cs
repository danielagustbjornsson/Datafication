using System.Linq;
using Datafication.Models.Dtos;
using Datafication.Repositories.Contexts;
using Datafication.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Datafication.Repositories.Implementations
{
    public class ManufacturerRepository : IManufacturerRepository
    {
        private DbContextOptions<DataficationDbContext> options;
        public ManufacturerDetailsDto GetManufacturerById(int id)
        {
            using var dbContext = new DataficationDbContext();

            var ManufacturerById = dbContext
                .Manufacturers
                .Where(m => m.Id == id)
                .Select(m => new ManufacturerDetailsDto
                {
                    Id = m.Id,
                    Name = m.Name,
                    ExternalUrl = m.ExternalUrl,
                    Bio = m.Bio
                }).ElementAtOrDefault(0);
            return ManufacturerById;
        }
    }
}