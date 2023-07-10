using Application.ServicesContracts;
using Crosscuting.CustomExceptions;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeController : ControllerBase
    {
        private readonly ILogger<RecipeController> _logger;
        private readonly IRecipeService _recipeService;

        public RecipeController(ILogger<RecipeController> logger, IRecipeService recipeService)
        {
            _recipeService = recipeService;
            _logger = logger;
        }

        [HttpGet]
        [Route("GetRecipePrice")]
        public async Task<IActionResult> GetRecipePrice(string recipeName)
        {
            try
            {
                decimal price = await _recipeService.GetRecipePrice(recipeName);

                return Ok($"This is the recipe price: {price}");
            }
            catch (NotRecipeFoundException ex)
            {
                _logger.LogInformation("Recipe name doesn`t exists");
                return Ok(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest($"{ex.Message}");
            }
        }
    }
}
