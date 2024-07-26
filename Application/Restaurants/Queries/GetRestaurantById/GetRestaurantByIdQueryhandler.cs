using AutoMapper;
using Domain.Exceptions;
using MediatR;
using Restaurants.Api.Application.Interfaces.Repositories;
using Restaurants.Api.Application.Restaurants.Dtos;
using Restaurants.Api.Domain.Entities;

namespace Application.Restaurants.Queries.GetRestaurantById
{
    public class GetRestaurantByIdQueryhandler(IRestaurantsRepository restaurantsRepository,
    IMapper mapper) : IRequestHandler<GetRestaurantByIdQuery, RestaurantDto>
    {
        public async Task<RestaurantDto> Handle(GetRestaurantByIdQuery request, CancellationToken cancellationToken)
        {
            var restaurant = await restaurantsRepository.GetByIdAsync(request.Id)
                ?? throw new NotFoundException(nameof(Restaurant), request.Id.ToString());
            return mapper.Map<RestaurantDto>(restaurant);
        }
    }
}
