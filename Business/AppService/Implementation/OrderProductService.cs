using AutoMapper;
using Business.AppService.Contract;
using Business.Helper.Extension;
using Domain.Entities;
using DTO;
using Repository.Contract;

namespace Business.AppService.Implementation
{
    public class OrderProductService : AppService<OrderProduct, OrderProductDTO>, IOrderProductService
    {
        private readonly IOrderProductRepository _orderProductRepository;
        private readonly IProductDiscountService _productDiscountService;
        private readonly IProductService _productService;
        public OrderProductService(IOrderProductRepository orderProductRepository
            , IProductDiscountService productDiscountService
            , IProductService productService, IMapper mapper) : base(orderProductRepository, mapper)
        {
            _orderProductRepository = orderProductRepository;
            _productDiscountService = productDiscountService;
            _productService = productService;
        }

        public override OrderProductDTO Add(OrderProductDTO orderProduct)
        {
            var product = _productService.Get(orderProduct.ProductId);
            var discount = GetDiscount(orderProduct);
            orderProduct.Amount = (product.Price * orderProduct.Quantity) - (product.Price * orderProduct.Quantity * discount / 100);
            var entity = _orderProductRepository.Add(orderProduct.ToEntity<OrderProduct>());
            return entity.ToDto<OrderProductDTO>();
        }

        private double GetDiscount(OrderProductDTO orderProduct)
        {
            var discount = _productDiscountService.GetByProductQuantity(orderProduct.ProductId, orderProduct.Quantity);
            return discount == null ? 0 : discount.Percentage;
        }
    }
}
