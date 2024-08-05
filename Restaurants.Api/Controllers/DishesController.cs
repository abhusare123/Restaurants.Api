using Application.Dishes.Command.CreateDish;
using Application.Dishes.Dtos;
using Application.Dishes.Queries.GetByIdForRestaurnt;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Restaurants.Api.Controllers;

namespace Restaurants.Api.Controllers
{
    [Route("api/restaurants/{restaurantId}/dishes")]
    [ApiController]
    [Authorize]
    public class DishesController(IMediator mediator) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateDish([FromRoute] int restaurantId, CreateDishCommand createDishCommand)
        {
            createDishCommand.RestaurantId = restaurantId;

            var dishId = await mediator.Send(createDishCommand);
            return CreatedAtAction(nameof(GetByIdForRestaurant), new { restaurantId, dishId }, null);
        }

        [HttpGet("{dishId}")]
        public async Task<ActionResult<DishDto>> GetByIdForRestaurant([FromRoute] int restaurantId, [FromRoute] int dishId)
        {
            var dish = await mediator.Send(new GetDishByIdForRestaurantQuery(restaurantId, dishId));
            return Ok(dish);
        }
    }
}
