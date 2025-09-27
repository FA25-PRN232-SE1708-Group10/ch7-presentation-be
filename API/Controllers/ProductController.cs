using API.Middlewares;
using BLL.Dtos;
using BLL.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(
            [FromQuery] int page = 1,
            [FromQuery] int pageSize = 10,
            [FromQuery] string? sortBy = null,
            [FromQuery] string? sortOrder = null
        )
        {
            var result = await _productService.GetAllAsync(page, pageSize, sortBy, sortOrder);
            return Ok(new ApiResponse<PaginatedResult<ProductDto>>(result));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _productService.GetByIdAsync(id);
            if (product == null)
                return NotFound(new ApiResponse<string>("Product not found"));
            return Ok(new ApiResponse<ProductDto>(product));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateProductDto dto)
        {
            var created = await _productService.CreateAsync(dto);
            return CreatedAtAction(
                nameof(GetById),
                new { id = created.Id },
                new ApiResponse<ProductDto>(created)
            );
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateProductDto dto)
        {
            var success = await _productService.UpdateAsync(id, dto);
            if (!success)
                return NotFound(new ApiResponse<string>("Product not found"));
            return Ok(new ApiResponse<string>(null, "Product updated successfully"));
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Patch(int id, [FromBody] PatchProductDto dto)
        {
            var success = await _productService.PatchAsync(id, dto);
            if (!success)
                return NotFound(new ApiResponse<string>("Product not found"));
            return Ok(new ApiResponse<string>(null, "Product patched successfully"));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _productService.DeleteAsync(id);
            if (!success)
                return NotFound(new ApiResponse<string>("Product not found"));
            return Ok(new ApiResponse<string>(null, "Product deleted successfully"));
        }
    }
}
