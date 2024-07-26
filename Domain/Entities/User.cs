namespace Restaurants.Api.Domain.Entities
{
    public class User
    {
        public DateOnly? DateOfBirth { get; set; }
        public string? Nationality { get; set; }

        public List<Restaurant> OwnedRestaurants { get; set; } = [];
    }
}