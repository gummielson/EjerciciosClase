using Application.ServicesContracts;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GeneralController : ControllerBase
    {
        private readonly ILogger<GeneralController> _logger;
        private readonly IGeneralService _generalService;

        public GeneralController(ILogger<GeneralController> logger, IGeneralService generalService)
        {
            _generalService = generalService;
            _logger = logger;
        }

        [HttpGet]
        [Route("SaveDataInMemory")]
        public async Task<IActionResult> SaveDataInMemory()
        {
            try
            {
                await _generalService.SaveDataInMemory();

                return Ok();
            }
            catch (Exception ex) 
            {
                _logger.LogError("Cant save data in file", ex.Message);
                return BadRequest($"Cant save data in file: {ex.Message}");
            }
        }
    }
}
