using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CentralSpecAPI.DTOs.Product;
using CentralSpecAPI.Services.Product;

namespace CentralSpecAPI.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ProductGroupController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductGroupController(IProductService productService)
        {
            this._productService = productService;

        }

        [HttpPost("addproductGroup")]
        public async Task<IActionResult> AddProductGroup(AddProductGroupDto newProductGroup)
        {
            return Ok(await _productService.AddProductGroup(newProductGroup));
        }


        [HttpGet("getAllProductGroup")]
        public async Task<IActionResult> GetAllProductGroup()
        {
            return Ok(await _productService.GetAllProductGroup());
        }


        [HttpGet("getProductGroupbyId/{productGroupId}")]
        public async Task<IActionResult> GetProductGroupById(int productGroupId)
        {
            return Ok(await _productService.GetProductGroupById(productGroupId));
        }

        [HttpPut("updateProductGroup")]
        public async Task<IActionResult> UpdateProductGroup(UpdateProductGroupDto updateProductGroup)
        {
            return Ok(await _productService.UpdateProductGroup(updateProductGroup));
        }

        [HttpGet("getProductGroupFilter")]
        public async Task<IActionResult> GetProductGroupFilter([FromQuery] ProductGroupFilterDto productGroupFilter)
        {
            return Ok(await _productService.GetProductGroupFilter(productGroupFilter));
        }
    }
}