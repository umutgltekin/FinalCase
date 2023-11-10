using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vk.Data.Domain;
using Vk.Schema;

namespace Vk.Operation.Mapper
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<UserResuest, User>();
            CreateMap<User, UserResponse>().ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.Id));

            CreateMap<DealerRequest, Dealer>();
            CreateMap<Dealer, DealerResponse>();

            CreateMap<ProductRequest, Product>();
            CreateMap<Product, ProductResponse>()
                .ForMember(dest => dest.DealerName, opt => opt.MapFrom(src => src.Dealer.FirstName+" "+src.Dealer.LastName));

            CreateMap<OrderRequest, Order>();
            CreateMap<Order, OrderResponse>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.FirstName + " " + src.User.LastName))
                .ForMember(dest => dest.DealerName, opt => opt.MapFrom(src => src.Dealer.FirstName + " " + src.Dealer.LastName));

            CreateMap<OrderItemsRequest, OrderItems>();
            CreateMap<OrderItems, OrderItemsResponse>()
                .ForMember(dest => dest.OrderName, opt => opt.MapFrom(src => src.Product.ProductName))
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Order.OrderName));

            CreateMap<AdressRequest, Address>();
            CreateMap<Address, AdressResponse>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.FirstName + " " + src.User.LastName));
        }
    }
}
