using AutoMapper;
using Domain.Entities;
using DTO;

namespace Business.Helper
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<Category, CategoryDTO>().ReverseMap();
            CreateMap<Order, OrderDTO>().ReverseMap();
            CreateMap<Product, ProductDTO>().ReverseMap();
            CreateMap<OrderProduct, OrderProductDTO>().ReverseMap();
            CreateMap<ProductDiscount, ProductDiscountDTO>().ReverseMap();
        }
    }
}
