using DTO;

namespace Business.AppService.Contract
{
    public interface IProductDiscountService : IAppService<ProductDiscountDTO>
    {
        ProductDiscountDTO GetByProductQuantity(int productID, int quantity);
    }
}
