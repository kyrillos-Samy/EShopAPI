using DTO;

namespace Business.AppService.Contract
{
    public interface IOrderService : IAppService<OrderDTO>
    {
        OrderDTO CreateOrder(OrderDTO order);
    }
}
