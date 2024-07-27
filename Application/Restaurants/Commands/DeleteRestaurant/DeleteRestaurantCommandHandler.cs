using MediatR;
using Restaurants.Api.Application.Interfaces.Repositories;

namespace Application.Restaurants.Commands.DeleteRestaurant
{
    internal class DeleteRestaurantCommandHandler(IRestaurantsRepository restaurantsRepository) : IRequestHandler<DeleteRestaurantCommand, bool>
    {
        public async Task<bool> Handle(DeleteRestaurantCommand request, CancellationToken cancellationToken)
        {
           var resturant = await restaurantsRepository.GetByIdAsync(request.Id);
           if (resturant == null)
           {
                return false;
           }
           await restaurantsRepository.Delete(resturant);
           return true;
        }
    }
}
