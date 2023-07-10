using Application.ServiceContracts;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    public class HomePriceByIdServiceController : Controller
    {
        public readonly ILogger<HomePriceByIdServiceController> _logger;
        private readonly IHomePriceByIdService _service;

        public HomePriceByIdServiceController(ILogger<HomePriceByIdServiceController> logger, IHomePriceByIdService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        [Route("GetHomePrice")]
        public async Task<IActionResult> GetHomePrice(int id)
        {
            try
            {
                decimal price = await _service.GetHomePrice(id);

                if(price == 0) 
                {
                    return Ok($"No home was found");
                }
                else
                {
                    return Ok($"This is the home price: {price}");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest($"{ex.Message}");
            }
        }
    }
}
