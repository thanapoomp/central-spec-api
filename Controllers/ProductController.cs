using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CentralSpecAPI.DTOs.Product;
using CentralSpecAPI.Services.Product;

namespace CentralSpecAPI.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            this._productService = productService;

        }

        [HttpPost("addproduct")]
        public async Task<IActionResult> AddProduct(AddProductDto newProduct)
        {
            return Ok(await _productService.AddProduct(newProduct));
        }


        [HttpGet("getproduct/{productId}")]
        public async Task<IActionResult> GetProduct(int productId)
        {
            return Ok(await _productService.GetProductById(productId));
        }


        [HttpPut("updateproduct")]
        public async Task<IActionResult> UpdateProduct(UpdateProductDto updateProduct)
        {
            return Ok(await _productService.UpdateProduct(updateProduct));
        }


        [HttpGet("filter")]
        public async Task<IActionResult> filter([FromQuery] ProductFilterDto filter)
        {
            return Ok(await _productService.GetProductFilter(filter));
        }


        [HttpGet("getproductByGroupId/{productGroupId}")]
        public async Task<IActionResult> GetProductByProductGroupId(int productGroupId)
        {
            return Ok(await _productService.GetProductByProductGroupId(productGroupId));
        }

    }
}