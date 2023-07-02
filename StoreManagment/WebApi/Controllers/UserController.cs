using Application.ServicesContracts;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;
        private readonly ILogger<UserController> _logger;

        public UserController(IUserService service, ILogger<UserController> logger)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        [Route("GetAllUsers")]
        public async Task<IActionResult> GetAllUsers()
        {
            try
            {
                return Ok(await _service.GetAllUsers());
            }
            catch (Exception ex)
            {
                _logger.LogError("Unable to get all users");

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
                return Ok("The user was deleted properly");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Unable to delete the selected user: {ex.Message}");

                return BadRequest($"Unable to delete the selected user: {ex.Message}");
            }
        }
    }
}