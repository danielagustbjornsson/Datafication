using Datafication.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Datafication.WebAPI.Controllers
{
    [ApiController]
    [Route("api/manufacturers")]
    public class ManufacturerController : ControllerBase
    {
        private readonly IManufacturerService _manufacturerService;

        public ManufacturerController(IManufacturerService manufacturerService)
        {
            _manufacturerService = manufacturerService;
        }

        [HttpGet]
        [Route("{manufacturerId}")]
        public IActionResult GetManufacturerById(int manufacturerId)
            => Ok(_manufacturerService.GetManufacturerById(manufacturerId));
    }
}