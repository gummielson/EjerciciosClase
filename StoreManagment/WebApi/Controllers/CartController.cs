using Application.ServicesContracts;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartService _service;
        private readonly ILogger<CartController> _logger;

        public CartController(ICartService service, ILogger<CartController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet]
        [Route("GetAllCarts")]
        public async Task<IActionResult> GetAllCarts()
        {
            try
            {
                return Ok(await _service.GetAllCarts());
            }
            catch (Exception ex)
            {
                _logger.LogError("Unable to get all carts");

                return BadRequest(ex.Message);
            }
        }
    }
}
