using Application.ServicesContracts;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _service;
        private readonly ILogger<ProductController> _logger;

        public ProductController(IProductService service, ILogger<ProductController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet]
        [Route("GetAllProducts")]
        public async Task<IActionResult> GetAllProducts()
        {
            try
            {
                return Ok(await _service.GetAllProducts());
            }
            catch (Exception ex)
            {
                _logger.LogError("Unable to get all proudcts");

                return BadRequest(ex.Message);
            }
        }

        //[HttpPost]
        //[Route("InsertProduct")]
        //public async Task<IActionResult> InsertProduct([Required] ProductDto product)
        //{
        //    try
        //    {
        //        var response = await _service.InsertProduct(product);

        //        return string.IsNullOrWhiteSpace(response.Result) ? Ok() : BadRequest(response.Result);
        //    }
        //    catch (Exception ex) 
        //    {
        //        _logger.LogError("Unable to insert product");

        //        return BadRequest(ex.Message);
        //    }
        //}

        //[HttpGet]
        //[Route("GetProductsByFilter")]
        //public async Task<IActionResult> GetProductsByFilter([Required] string filter)
        //{
        //    try
        //    {
        //        return Ok(await _service.GetProductsByFilter(filter));
        //    }
        //    catch (Exception ex) 
        //    {
        //        _logger.LogError("Unable to get products by filter");

        //        return BadRequest(ex.Message);
        //    }
        //}
    }
}
