using BLL.Dtos;

namespace BLL.Services
{
    public interface IProductService
    {
        Task<PaginatedResult<ProductDto>> GetAllAsync(int page, int pageSize);
        Task<ProductDto?> GetByIdAsync(int id);
        Task<ProductDto> CreateAsync(CreateProductDto dto);
        Task<bool> UpdateAsync(int id, UpdateProductDto dto);
        Task<bool> PatchAsync(int id, PatchProductDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
