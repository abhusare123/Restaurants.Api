using MediatR;
using Restaurants.Api.Application.Restaurants.Dtos;

namespace Application.Restaurants.Queries.GetRestaurantById
{
    public class GetRestaurantByIdQuery(int id) : IRequest<RestaurantDto>
    {
        public int Id { get; } = id;
    }
}
