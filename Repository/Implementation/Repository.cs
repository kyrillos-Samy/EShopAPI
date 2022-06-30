using Domain;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Contract;
using System.Linq.Expressions;

namespace Repository.Implementation
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        protected Repository(EShopDBContext context)
        {
            Context = context;
            DbSet = Context.Set<TEntity>();
        }

        public IQueryable<TEntity> All { get { return DbSet.AsNoTracking(); } }

        protected EShopDBContext Context { get; }

        protected DbSet<TEntity> DbSet { get; set; }

        protected string UserId { get; private set; }

        public virtual TEntity Add(TEntity entity)
        {
            DbSet.Add(entity);
            Context.SaveChanges();
            return entity;
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            DbSet.AddRange(entities);
            Context.SaveChanges();
        }


        public virtual TEntity Update(TEntity entity)
        {
            DbSet.Update(entity);
            Context.SaveChanges();
            return entity;
        }

        public TEntity Delete(int id)
        {
            var entity = DbSet.Find(id);
            if (entity != null)
            {
                DbSet.Remove(entity);
                Context.SaveChanges();
                return entity;
            }
            return null;
        }

        public void DeleteRange(IList<int> idList)
        {
            var entities = DbSet.Where(e => idList.Contains(e.Id));
            DbSet.RemoveRange(entities);
            Context.SaveChanges();
        }
        public IEnumerable<TEntity> GetAll()
        {
          return All.OrderBy(e => e.Id).ToList();
        }
        public IEnumerable<TEntity> GetAll(int pageNumber = 1, int pageSize = 20, string sort = null, bool ascending = true)
        {
            if (sort == null)
                return All.OrderBy(e => e.Id).ToList();

            if (ascending)
            {
                return All.OrderBy(e => sort).ToList();
            }
            return All.OrderByDescending(e => sort).ToList();
        }


        public virtual TEntity Get(int id)
        {
            try
            {
                return DbSet.AsNoTracking().FirstOrDefault(x => x.Id == id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<TEntity> GetAllIncluding(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "")
        {
            IQueryable<TEntity> query = DbSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }
            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }
    }
}
