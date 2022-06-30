using AutoMapper;
using Business.AppService.Contract;
using Business.Helper.Extension;
using Domain.Entities;
using DTO;
using Repository.Contract;

namespace Business.AppService.Implementation
{
    public class ProductDiscountService : AppService<ProductDiscount, ProductDiscountDTO>, IProductDiscountService
    {
        private readonly IProductDiscountRepository _productDiscountRepository;
        public ProductDiscountService(IProductDiscountRepository productDiscountRepository, IMapper mapper) : base(productDiscountRepository, mapper)
        {
            _productDiscountRepository = productDiscountRepository;
        }

        public ProductDiscountDTO GetByProductQuantity(int productID, int quantity)
        {
            return _productDiscountRepository.GetAllIncluding(x => x.ProductId == productID && x.Quantity <= quantity).FirstOrDefault().ToDto<ProductDiscountDTO>();
        }
    }
}
