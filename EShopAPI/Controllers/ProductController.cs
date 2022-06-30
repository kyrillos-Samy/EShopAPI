using Business.AppService.Contract;
using DTO;
using EShopAPI.Controllers.Base;
using Microsoft.AspNetCore.Mvc;

namespace EShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : BaseController<ProductDTO>
    {
        protected new readonly IProductService _appService;
        public ProductController(IProductService appService) : base(appService)
        {
            _appService = appService;
        }

        [HttpPost("AddDiscount")]
        public virtual ProductDiscountDTO AddDiscount(ProductDiscountDTO dto)
        {
            try
            {
                return _appService.AddDiscount(dto);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
