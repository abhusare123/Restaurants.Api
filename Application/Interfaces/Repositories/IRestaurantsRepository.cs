using Restaurants.Api.Domain.Entities;

namespace Restaurants.Api.Application.Interfaces.Repositories
{
    public interface IRestaurantsRepository
    {
        Task<IEnumerable<Restaurant>> GetAllAsync();
        Task<Restaurant> GetByIdAsync(int id);
        Task<int> Create(Restaurant entity);
        Task Delete(Restaurant resturant);
        Task SaveChanges();
    }
}