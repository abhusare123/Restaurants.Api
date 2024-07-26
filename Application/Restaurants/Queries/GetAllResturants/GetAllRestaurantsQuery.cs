using MediatR;
using Restaurants.Api.Application.Restaurants.Dtos;

namespace Restaurants.Api.Application.Restaurants.Queries.GetAllRestaurants
{
    public class GetAllRestaurantsQuery : IRequest<IEnumerable<RestaurantDto>>
    {

    }
}
