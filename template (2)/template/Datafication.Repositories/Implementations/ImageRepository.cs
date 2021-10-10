using System.Collections.Generic;
using System.Linq;
using Datafication.Models.Dtos;
using Datafication.Models.InputModels;
using Datafication.Repositories.Contexts;
using Datafication.Repositories.Entities;
using Datafication.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Datafication.Repositories.Implementations
{
    public class ImageRepository : IImageRepository
    {
        private DbContextOptions<DataficationDbContext> options;
        public int CreateNewImage(ImageInputModel image)
        {
            using var dbContext = new DataficationDbContext();

            var newImage = new Image
            {
                Url = image.Url,
                IceCreamId = image.IceCreamId
            };
            dbContext.Images.Add(newImage);
            dbContext.SaveChanges();
            return newImage.Id;
        }

        public IEnumerable<ImageDto> GetAllImagesByIceCreamId(int iceCreamId)
        {
            using var dbContext = new DataficationDbContext();

            var allImagesByIceCreamId = dbContext
                .Images
                .Where(I => I.IceCreamId == iceCreamId)
                .Select(I => new ImageDto
                {
                    Id = I.Id,
                    Url = I.Url
                });

            return allImagesByIceCreamId;

            
        }

        public ImageDetailsDto GetImageById(int id)
        {
            using var dbContext = new DataficationDbContext();

            var OneImageById = dbContext
                .Images
                .Where(I => I.Id == id)
                .Select(I => new ImageDetailsDto
                {
                    Id = I.Id,
                }).ElementAtOrDefault(0);

            return OneImageById;
        }
    }
}