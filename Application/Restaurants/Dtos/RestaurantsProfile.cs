using Application.Restaurants.Commands.CreateRestaurant;
using AutoMapper;
using Restaurants.Api.Domain.Entities;

namespace Restaurants.Api.Application.Restaurants.Dtos
{
    public class RestaurantsProfile : Profile
    {
        public RestaurantsProfile()
        {
            CreateMap<Restaurant, RestaurantDto>()
                .ForMember(d => d.City, opt =>
                    opt.MapFrom(src => src.Address == null ? null : src.Address.City))
                .ForMember(d => d.PostalCode, opt =>
                    opt.MapFrom(src => src.Address == null ? null : src.Address.PostalCode))
                .ForMember(d => d.Street, opt =>
                    opt.MapFrom(src => src.Address == null ? null : src.Address.Street))
                .ForMember(d => d.Dishes, opt => opt.MapFrom(src => src.Dishes));

            CreateMap<CreateRestaurantCommand, Restaurant>()
            .ForMember(d => d.Address, opt => opt.MapFrom(
                src => new Address
                {
                    City = src.City,
                    PostalCode = src.PostalCode,
                    Street = src.Street
                }));
        }
    }
}
