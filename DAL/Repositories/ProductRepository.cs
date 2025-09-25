using DAL.Data;
using DAL.Entities;

namespace DAL.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext context)
            : base(context) { }
    }
}
