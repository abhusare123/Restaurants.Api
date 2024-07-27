using Application.Interfaces.Repositories;
using AutoMapper;
using Domain.Exceptions;
using MediatR;
using Restaurants.Api.Application.Interfaces.Repositories;
using Restaurants.Api.Domain.Entities;

namespace Application.Dishes.Command.CreateDish
{
    public class CreateDishCommandHandler(IRestaurantsRepository restaurantsRepository,
    IDishesRepository dishesRepository,
    IMapper mapper) : IRequestHandler<CreateDishCommand, int>
    {
        public async Task<int> Handle(CreateDishCommand request, CancellationToken cancellationToken)
        {
            var restaurant = await restaurantsRepository.GetByIdAsync(request.RestaurantId);
            if (restaurant == null) throw new NotFoundException(nameof(Restaurant), request.RestaurantId.ToString());

            
            var dish = mapper.Map<Dish>(request);

            return await dishesRepository.Create(dish);
        }
    }
}
