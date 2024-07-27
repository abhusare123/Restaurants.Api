using AutoMapper;
using Domain.Exceptions;
using MediatR;
using Restaurants.Api.Application.Interfaces.Repositories;
using Restaurants.Api.Domain.Entities;

namespace Application.Restaurants.Commands.UpdateRestaurant
{
    internal class UpdateRestaurantCommandHandler(IRestaurantsRepository restaurantsRepository,
        IMapper mapper) : IRequestHandler<UpdateRestaurantCommand>
    {
        public async Task Handle(UpdateRestaurantCommand command, CancellationToken cancellationToken)
        {
            var restaurant = await restaurantsRepository.GetByIdAsync(command.Id);
            if (restaurant == null)
            {
                throw new NotFoundException(nameof(Restaurant), command.Id.ToString());
            }

            mapper.Map(command, restaurant);
            await restaurantsRepository.SaveChanges();
        }
    }
}
