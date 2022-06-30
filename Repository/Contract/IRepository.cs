using Domain.Entities;
using System.Linq.Expressions;

namespace Repository.Contract
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        IQueryable<TEntity> All { get; }
        TEntity Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> dto);
        TEntity Update(TEntity entity);
        TEntity Delete(int id);
        void DeleteRange(IList<int> idList);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> GetAll(int pageNumber, int pageSize, string sort, bool ascending);
        TEntity Get(int id);
        IEnumerable<TEntity> GetAllIncluding(
          Expression<Func<TEntity, bool>> filter = null,
          Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
          string includeProperties = "");
    }
}
