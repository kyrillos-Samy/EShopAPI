using Business.AppService.Contract;
using Common.Contract;
using DTO;
using Microsoft.AspNetCore.Mvc;

namespace EShopAPI.Controllers.Base
{
    public class BaseController<TDTO> : ControllerBase where TDTO : BaseDTO
    {
        protected readonly IAppService<TDTO> _appService;

        public BaseController(IAppService<TDTO> appService)
        {
            _appService = appService;
        }

        #region Get
        [HttpGet("Get")]
        public virtual IPagedList<BaseDTO> Get(int pageNumber, int pageSize, string sort, bool ascending)
        {
            var result = (IPagedList<BaseDTO>)_appService.GetAll(pageNumber, pageSize, sort, @ascending);
            return result;
        }

        [HttpGet("GetById/{id}")]
        public virtual TDTO GetById(int id)
        {
            var dto = _appService.Get(id);
            return dto;
        }

        [HttpGet("GetAll")]
        public virtual IEnumerable<TDTO> GetAll()
        {
            var dto = _appService.GetAll();
            return dto;
        }

        #endregion

        #region Create

        [HttpPost("Add")]
        public virtual TDTO Add(TDTO dto)
        {
            try
            {
                return _appService.Add(dto);
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Edit

        [HttpPut("Update")]
        public virtual TDTO Update(TDTO entity)
        {
            try
            {
                return _appService.Update(entity); 
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
    }
}
