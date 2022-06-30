using Domain;
using Domain.Entities;
using Repository.Contract;

namespace Repository.Implementation
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(EShopDBContext context) : base(context)
        {

        }
    }
}
