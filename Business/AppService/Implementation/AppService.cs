using AutoMapper;
using Business.AppService.Contract;
using Business.Helper;
using Business.Helper.Extension;
using Domain.Entities;
using DTO;
using Repository.Contract;

namespace Business.AppService.Implementation
{
    public class AppService<TEnity, TDTO> : IAppService<TDTO> where TEnity : BaseEntity where TDTO : BaseDTO
    {
        protected readonly IRepository<TEnity> _repository;

        public AppService(IRepository<TEnity> repository, IMapper mapper)
        {
            _repository = repository;
            AutoMapperConfiguration.Mapper = mapper;
            Repositories.Add(_repository);
        }

        public List<object> Repositories { get; set; } = new List<object>();


        public virtual TDTO Add(TDTO dto)
        {
            var entity = dto.ToEntity<TEnity>();
            var updatedEnity = _repository.Add(entity);
            return updatedEnity.ToDto<TDTO>();
        }

        public TDTO Update(TDTO dto)
        {
            var entity = dto.ToEntity<TEnity>();
            var updatedEnity = _repository.Update(entity);
            return updatedEnity.ToDto<TDTO>();
        }


        public TDTO Delete(int id)
        {
            var updatedEnity = _repository.Delete(id);
            return updatedEnity.ToDto<TDTO>();
        }

        public TDTO Get(int id)
        {
            var obj = _repository.Get(id).ToDto<TDTO>();
            return obj;
        }
        public IEnumerable<TDTO> GetAll()
        {
            return _repository.GetAll().Select(e => e.ToDto<TDTO>());
        }

        public IEnumerable<TDTO> GetAll(int pageNumber, int pageSize, string sort, bool ascending = true)
        {
            return _repository.GetAll(pageNumber, pageSize, sort, ascending).Select(e => e.ToDto<TDTO>());
        }

    }
}
