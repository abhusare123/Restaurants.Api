using AutoMapper;
using MediatR;
using Restaurants.Api.Application.Interfaces.Repositories;
using Restaurants.Api.Domain.Entities;

namespace Application.Restaurants.Commands.CreateRestaurant
{
    internal class CreateRestaurantCommandHandler(IMapper mapper,
    IRestaurantsRepository restaurantsRepository) : IRequestHandler<CreateRestaurantCommand, int>
    {
        public async Task<int> Handle(CreateRestaurantCommand request, CancellationToken cancellationToken)
        {
            var restaurant = mapper.Map<Restaurant>(request);
            var id = await restaurantsRepository.Create(restaurant);
            return id;
        }
    }
}
