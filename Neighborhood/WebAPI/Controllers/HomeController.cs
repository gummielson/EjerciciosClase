using Application.ServiceContracts;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    public class HomeController : Controller
    {
        public readonly ILogger<HomeController> _logger;
        private readonly IHomeService _service;

        public HomeController(ILogger<HomeController> logger, IHomeService service)
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

                return Ok($"This is the recipe price: {price}");
            }
            //catch (NotRecipeFoundException ex)
            //{
            //    _logger.LogInformation("Recipe name doesn`t exists");
            //    return Ok(ex.Message);
            //}
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest($"{ex.Message}");
            }
        }
    }
}
