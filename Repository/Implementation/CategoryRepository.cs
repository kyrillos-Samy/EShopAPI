using Domain;
using Domain.Entities;
using Repository.Contract;

namespace Repository.Implementation
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(EShopDBContext context) : base(context)
        {

        }
    }
}
