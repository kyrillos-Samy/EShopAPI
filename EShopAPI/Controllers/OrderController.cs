using Business.AppService.Contract;
using DTO;
using EShopAPI.Controllers.Base;
using Microsoft.AspNetCore.Mvc;

namespace EShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : BaseController<OrderDTO>
    {
        protected new readonly IOrderService _appService;
        protected readonly IOrderProductService _orderProductService;
        public OrderController(IOrderService appService, IOrderProductService orderProductService) : base(appService)
        {
            _appService = appService;
            _orderProductService = orderProductService;
        }

        [HttpPost("CreateOrder")]
        public virtual OrderDTO CreateOrder(OrderDTO dto)
        {
            try
            {
                return _appService.CreateOrder(dto);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
