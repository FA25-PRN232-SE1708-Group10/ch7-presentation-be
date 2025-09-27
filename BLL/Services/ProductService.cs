using AutoMapper;
using BLL.Dtos;
using DAL.Entities;
using DAL.Repositories;

namespace BLL.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<PaginatedResult<ProductDto>> GetAllAsync(int page, int pageSize, string? sortBy = null, string? sortOrder = null)
        {
            var (Products, totalCount) = await _productRepository.GetPaginatedAsync(page, pageSize, sortBy, sortOrder);
            return new PaginatedResult<ProductDto>
            {
                Items = _mapper.Map<IEnumerable<ProductDto>>(Products),
                TotalResults = totalCount,
                Page = page,
                PageSize = pageSize,
            };
        }

        public async Task<ProductDto?> GetByIdAsync(int id)
        {
            var Product = await _productRepository.GetByIdAsync(id);
            return Product == null ? null : _mapper.Map<ProductDto>(Product);
        }

        public async Task<ProductDto> CreateAsync(CreateProductDto dto)
        {
            var product = _mapper.Map<Product>(dto);
            await _productRepository.AddAsync(product);
            await _productRepository.SaveChangesAsync();
            return _mapper.Map<ProductDto>(product);
        }

        public async Task<bool> UpdateAsync(int id, UpdateProductDto dto)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null)
                return false;
            _mapper.Map(dto, product);
            _productRepository.Update(product);
            await _productRepository.SaveChangesAsync();
            return true;
        }

        public async Task<bool> PatchAsync(int id, PatchProductDto dto)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null)
                return false;
            if (dto.Name != null)
                product.Name = dto.Name;
            if (dto.Price != null)
                product.Price = dto.Price.Value;
            _productRepository.Update(product);
            await _productRepository.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null)
                return false;
            _productRepository.Remove(product);
            await _productRepository.SaveChangesAsync();
            return true;
        }
    }
}
