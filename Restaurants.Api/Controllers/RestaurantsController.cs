using Application.Restaurants.Commands.CreateRestaurant;
using Application.Restaurants.Commands.DeleteRestaurant;
using Application.Restaurants.Commands.UpdateRestaurant;
using Application.Restaurants.Queries.GetRestaurantById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Restaurants.Api.Application.Restaurants.Dtos;
using Restaurants.Api.Application.Restaurants.Queries.GetAllRestaurants;

namespace Restaurants.Api.Controllers
{
    [Route("api/restaurants")]
    [ApiController]
    [Authorize]
    public class RestaurantsController(IMediator mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RestaurantDto>>> Get()
        {
            var restaurants = await mediator.Send(new GetAllRestaurantsQuery());
            return Ok(restaurants);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RestaurantDto>> Get([FromRoute]int id)
        {
            var restaurant = await mediator.Send(new GetRestaurantByIdQuery(id));
            return Ok(restaurant);
        }

        [HttpPost]
        public async Task<ActionResult<RestaurantDto>> Create(CreateRestaurantCommand command)
        {
           var createdRestaurantId = await mediator.Send(command);
            return Ok(createdRestaurantId);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteResturant([FromRoute] int id)
        {
            var isDeleted = await mediator.Send(new DeleteRestaurantCommand(id));
            if (isDeleted)
            {
                return NoContent();
            }
            return NotFound();
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateResturant([FromRoute] int id, UpdateRestaurantCommand command)
        {
            command.Id = id;
            await mediator.Send(command);
            return NoContent();
        }
    }
}
