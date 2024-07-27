using Restaurants.Api.Domain.Entities;

namespace Application.Interfaces.Repositories
{
    public interface IDishesRepository
    {
        Task<int> Create(Dish entity);
        Task Delete(IEnumerable<Dish> entities);
    }
}