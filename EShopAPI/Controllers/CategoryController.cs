using Business.AppService.Contract;
using DTO;
using EShopAPI.Controllers.Base;
using Microsoft.AspNetCore.Mvc;

namespace EShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : BaseController<CategoryDTO>
    {
        protected new readonly ICategoryService _appService;
        public CategoryController(ICategoryService appService) : base(appService)
        {
            _appService = appService;
        }
    }
}
