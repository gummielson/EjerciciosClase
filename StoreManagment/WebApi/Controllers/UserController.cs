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

        //[HttpGet]
        //[Route("SaveProductsFromExternalApi")]
        //public async Task<IActionResult> SaveProductsFromExternalApi()
        //{
        //    try
        //    {
        //        await _service.SaveDataFromExternalApi();

        //        return Ok();
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError("Can't save data");

        //        return BadRequest(ex.Message);
        //    }
        //}

        //[HttpGet]
        //[Route("GetAllUsers")]
        //public async Task<IActionResult> GetAllUsers()
        //{
        //    try
        //    {
        //        return Ok(await _service.GetAllUsers());
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError("Unable to get all users");

        //        return BadRequest(ex.Message);
        //    }
        //}
    }
}