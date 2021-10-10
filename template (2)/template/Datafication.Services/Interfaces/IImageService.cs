using System.Collections.Generic;
using Datafication.Models.Dtos;
using Datafication.Models.InputModels;

namespace Datafication.Services.Interfaces
{
    public interface IImageService
    {
         ImageDetailsDto GetImageById(int id);
         IEnumerable<ImageDto> GetAllImagesByIceCreamId(int iceCreamId);
         int CreateNewImage(ImageInputModel image);
    }
}