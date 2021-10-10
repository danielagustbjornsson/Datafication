using System.Collections.Generic;
using Datafication.Models.Dtos;
using Datafication.Models.InputModels;
using Datafication.Repositories.Interfaces;
using Datafication.Services.Interfaces;

namespace Datafication.Services.Implementations
{
    public class ImageService : IImageService
    {
        private readonly IImageRepository _imageRepository;

        public ImageService(IImageRepository imageRepository)
        {
            _imageRepository = imageRepository;
        }

        public int CreateNewImage(ImageInputModel image)
            => _imageRepository.CreateNewImage(image);

        public IEnumerable<ImageDto> GetAllImagesByIceCreamId(int iceCreamId)
            => _imageRepository.GetAllImagesByIceCreamId(iceCreamId);

        public ImageDetailsDto GetImageById(int id)
            => _imageRepository.GetImageById(id);
    }
}