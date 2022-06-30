using AutoMapper;
using Business.AppService.Contract;
using Domain.Entities;
using DTO;
using Repository.Contract;

namespace Business.AppService.Implementation
{
    public class CategoryService : AppService<Category, CategoryDTO>, ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper) : base(categoryRepository, mapper)
        {
            _categoryRepository = categoryRepository;
        }
    }
}
