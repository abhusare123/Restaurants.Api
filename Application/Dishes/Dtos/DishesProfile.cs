using Application.Dishes.Command.CreateDish;
using AutoMapper;
using Restaurants.Api.Domain.Entities;

namespace Application.Dishes.Dtos
{
    public class DishesProfile : Profile
    {
        public DishesProfile()
        {
            CreateMap<Dish, DishDto>();
            CreateMap<CreateDishCommand, Dish>();
        }
    }
}
