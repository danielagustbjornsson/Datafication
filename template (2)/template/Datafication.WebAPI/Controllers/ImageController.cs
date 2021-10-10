using Datafication.Models.InputModels;
using Datafication.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Datafication.WebAPI.Controllers
{
    [ApiController]
    [Route("api/images")]
    public class ImageController : ControllerBase
    {
        private readonly IImageService _imageService;

        public ImageController(IImageService imageService)
        {
            _imageService = imageService;
        }

        [HttpGet]
        [Route("{imageId}", Name = "GetImageById")]
        public IActionResult GetImageById(int imageId)
            => Ok(_imageService.GetImageById(imageId));

        [HttpPost]
        [Route("")]
        public IActionResult CreateNewImage([FromBody] ImageInputModel image)
        {
            var id = _imageService.CreateNewImage(image);
            return CreatedAtRoute("GetImageById", new { imageId = id }, null);
        }
    }
}