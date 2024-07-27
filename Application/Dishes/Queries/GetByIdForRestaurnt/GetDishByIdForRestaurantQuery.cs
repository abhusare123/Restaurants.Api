using Application.Dishes.Dtos;
using MediatR;

namespace Application.Dishes.Queries.GetByIdForRestaurnt
{
    public class GetDishByIdForRestaurantQuery(int restaurantId, int dishId) : IRequest<DishDto>
    {
        public int RestaurantId { get; } = restaurantId;
        public int DishId { get; } = dishId;
    }
}
