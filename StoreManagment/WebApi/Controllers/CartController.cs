using Application.Dtos;
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

        [HttpDelete]
        [Route("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _service.Delete(id);

                return Ok("The entered cart was deleted properly.");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Unable to delete cart: {ex.Message}");

                return BadRequest($"Unable to delete cart: {ex.Message}");
            }
        }

        [HttpPost]
        [Route("InsertCart")]
        public async Task<IActionResult> InsertCart(CartDto Cart)
        {
            try
            {
                await _service.InsertCart(Cart);

                return Ok("The Cart was inserted properly");
            }
            catch (Exception ex)
            {
                _logger.LogError("Unable to insert Cart");

                return BadRequest(ex.Message);
            }
        }
    }
}
