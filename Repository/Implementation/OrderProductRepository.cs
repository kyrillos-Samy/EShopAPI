using Domain;
using Domain.Entities;
using Repository.Contract;

namespace Repository.Implementation
{
    public class OrderProductRepository : Repository<OrderProduct>, IOrderProductRepository
    {
        public OrderProductRepository(EShopDBContext context) : base(context)
        {

        }
    }
}
