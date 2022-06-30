using DTO;

namespace Business.AppService.Contract
{
    public interface IProductService : IAppService<ProductDTO>
    {
        public ProductDiscountDTO AddDiscount(ProductDiscountDTO dto);
    }
}
