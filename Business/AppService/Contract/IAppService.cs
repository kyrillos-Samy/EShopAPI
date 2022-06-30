using DTO;

namespace Business.AppService.Contract
{
    public interface IAppService<TDTO> where TDTO : BaseDTO
    {
        List<object> Repositories { get; set; }
        TDTO Add(TDTO dto);
        TDTO Update(TDTO dto);
        TDTO Delete(int id);
        TDTO Get(int id);
        IEnumerable<TDTO> GetAll();
        IEnumerable<TDTO> GetAll(int pageNumber, int pageSize, string sort, bool ascending = true);
    }
}
