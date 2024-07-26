using AutoMapper;
using MediatR;
using Restaurants.Api.Application.Interfaces.Repositories;
using Restaurants.Api.Application.Restaurants.Dtos;
using Restaurants.Api.Application.Restaurants.Queries.GetAllRestaurants;

namespace Restaurants.Api.Application.Restaurants.Queries.GetAllResturants
{
    public class GetAllRestaurantsQueryHandler(IMapper mapper,
        IRestaurantsRepository restaurantsRepository) : IRequestHandler<GetAllRestaurantsQuery, IEnumerable<RestaurantDto>>
    {
        public async Task<IEnumerable<RestaurantDto>> Handle(GetAllRestaurantsQuery request, CancellationToken cancellationToken)
        {
            var restaurants = await restaurantsRepository.GetAllAsync();
            return mapper.Map<IEnumerable<RestaurantDto>>(restaurants);
        }
    }
}
