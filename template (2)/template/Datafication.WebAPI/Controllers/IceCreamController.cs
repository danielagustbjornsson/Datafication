using Datafication.Models.InputModels;
using Datafication.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Datafication.WebAPI.Controllers
{
    [ApiController]
    [Route("api/icecreams")]
    public class IceCreamController : ControllerBase
    {
        private readonly IIceCreamService _iceCreamService;
        private readonly IImageService _imageService;

        public IceCreamController(IIceCreamService iceCreamService, IImageService imageService)
        {
            _iceCreamService = iceCreamService;
            _imageService = imageService;
        }

        [HttpGet]
        [Route("")]
        public IActionResult GetAllIceCreams()
            => Ok(_iceCreamService.GetAllIceCreams());
        
        [HttpGet]
        [Route("{iceCreamId}", Name = "GetIceCreamById")]
        public IActionResult GetIceCreamById(int iceCreamId)
            => Ok(_iceCreamService.GetIceCreamById(iceCreamId));

        [HttpGet]
        [Route("{iceCreamId}/images")]
        public IActionResult GetAllImagesByIceCreamId(int iceCreamId)
            => Ok(_imageService.GetAllImagesByIceCreamId(iceCreamId));

        [HttpPost]
        [Route("")]
        public IActionResult CreateNewIceCream([FromBody] IceCreamInputModel iceCream)
        {
            var id = _iceCreamService.CreateNewIceCream(iceCream);
            return CreatedAtRoute("GetIceCreamById", new { iceCreamId = id }, null);
        }

        [HttpPut]
        [Route("{iceCreamId}")]
        public IActionResult UpdateIceCream(int iceCreamId, [FromBody] IceCreamInputModel iceCream)
        {
            _iceCreamService.UpdateIceCream(iceCreamId, iceCream);
            return NoContent();
        }

        [HttpDelete]
        [Route("{iceCreamId}")]
        public IActionResult DeleteIceCream(int iceCreamId)
        {
            _iceCreamService.DeleteIceCream(iceCreamId);
            return NoContent();
        }

        [HttpPatch]
        [Route("{iceCreamId}/categories/{categoryId}")]
        public IActionResult AddIceCreamToCategory(int iceCreamId, int categoryId)
        {
            _iceCreamService.AddIceCreamToCategory(iceCreamId, categoryId);
            return NoContent();
        }
    }
}
