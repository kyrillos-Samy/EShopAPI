using AutoMapper;
using Business.AppService.Contract;
using Domain.Entities;
using DTO;
using Repository.Contract;

namespace Business.AppService.Implementation
{
    public class ProductService : AppService<Product, ProductDTO>, IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IProductDiscountService _productDiscountService;
        public ProductService(IProductRepository productRepository, IProductDiscountService productDiscountService, IMapper mapper) : base(productRepository, mapper)
        {
            _productRepository = productRepository;
            _productDiscountService = productDiscountService;
        }

        public ProductDiscountDTO AddDiscount(ProductDiscountDTO dto)
        {
            return _productDiscountService.Add(dto);
        }
    }
}
