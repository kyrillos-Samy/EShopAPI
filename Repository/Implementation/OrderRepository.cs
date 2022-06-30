using Domain;
using Domain.Entities;
using Repository.Contract;

namespace Repository.Implementation
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(EShopDBContext context) : base(context)
        {

        }
    }
}
