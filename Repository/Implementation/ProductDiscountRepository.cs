using Domain;
using Domain.Entities;
using Repository.Contract;

namespace Repository.Implementation
{
    public class ProductDiscountRepository : Repository<ProductDiscount>, IProductDiscountRepository
    {
        public ProductDiscountRepository(EShopDBContext context) : base(context)
        {

        }
    }
}
