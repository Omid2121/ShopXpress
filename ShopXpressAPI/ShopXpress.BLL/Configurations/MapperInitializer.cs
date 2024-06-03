using AutoMapper;
using ShopXpress.Bll.DTOs;
using ShopXpress.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopXpress.BLL.Configurations;

public class MapperInitializer : Profile
{
    public MapperInitializer()
    {
        // Cart DTOs 
        CreateMap<Cart, CartDTO>().ReverseMap();
        CreateMap<Cart, CreateCartDTO>().ReverseMap();
        CreateMap<Cart, UpdateCartDTO>().ReverseMap();

        // CartItem DTOs 
        CreateMap<CartItem, CartItemDTO>().ReverseMap();
        CreateMap<CartItem, CreateCartItemDTO>().ReverseMap();
        CreateMap<CartItem, UpdateCartItemDTO>().ReverseMap();

        // Category DTOs 
        CreateMap<Category, CategoryDTO>().ReverseMap();
        CreateMap<Category, CreateCategoryDTO>().ReverseMap();
        CreateMap<Category, UpdateCategoryDTO>().ReverseMap();

        // Order DTOs 
        CreateMap<Order, OrderDTO>().ReverseMap();
        CreateMap<Order, CreateOrderDTO>().ReverseMap();
        CreateMap<Order, UpdateOrderDTO>().ReverseMap();

        // OrderItem DTOs 
        CreateMap<OrderItem, OrderItemDTO>().ReverseMap();
        CreateMap<OrderItem, CreateOrderItemDTO>().ReverseMap();
        CreateMap<OrderItem, UpdateOrderItemDTO>().ReverseMap();

        // Product DTOs 
        CreateMap<Product, ProductDTO>().ReverseMap();
        CreateMap<Product, CreateProductDTO>().ReverseMap();
        CreateMap<Product, UpdateProductDTO>().ReverseMap();

        // User DTOs 
        CreateMap<User, UserDTO>().ReverseMap();
        CreateMap<User, CreateUserDTO>().ReverseMap();
        CreateMap<User, UpdateUserDTO>().ReverseMap();
    }
}
