using AutoMapper;
using DTO;
using Entites;

namespace pets
{
    public class Mapper:Profile
    {
        public Mapper()
        {
        CreateMap<Product, ProductDTO>().ReverseMap();
        CreateMap<OrderItem, OrderItemDTO>().ReverseMap();
        CreateMap<Category, CategoryDTO>().ReverseMap();
        CreateMap<Order,OrderDTO>().ReverseMap();
        CreateMap<User,UserDTO>();
        CreateMap<User,UserSavedDTO>();
        }
    }
}
