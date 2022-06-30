using AutoMapper;
using Business.AppService.Contract;
using Business.Helper.Extension;
using Domain.Entities;
using DTO;
using Repository.Contract;
using System.Transactions;

namespace Business.AppService.Implementation
{
    public class OrderService : AppService<Order, OrderDTO>, IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderProductService _orderProductService;
        public OrderService(IOrderRepository orderRepository, IOrderProductService orderProductService, IMapper mapper) : base(orderRepository, mapper)
        {
            _orderRepository = orderRepository;
            _orderProductService = orderProductService;
        }

        public OrderDTO CreateOrder(OrderDTO order)
        {
            var items = order.Items;
            using (var scope = new TransactionScope(TransactionScopeOption.Required,
                new TransactionOptions { IsolationLevel = IsolationLevel.ReadCommitted }))
            {
                try
                {
                    var orderEntity = _orderRepository.Add(order.ToEntity<Order>());
                    var orderProducts = SaveOrderProducts(orderEntity.Id, items);
                    if (orderProducts == null) return order;
                    orderEntity.TotalAmount = orderProducts.Sum(x => x.Amount);
                    order = _orderRepository.Update(orderEntity).ToDto<OrderDTO>();
                    scope.Complete();
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return order;
        }

        private List<OrderProductDTO> SaveOrderProducts(int orderId, List<OrderProductDTO> items)
        {
            if (items == null) return null;
            List<OrderProductDTO> orderProducts = new List<OrderProductDTO>();
            foreach (var item in items)
            {
                item.OrderId = orderId;
                orderProducts.Add(_orderProductService.Add(item));
            }
            return orderProducts;
        }
    }
}
