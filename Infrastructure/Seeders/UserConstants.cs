using Domain.Identity;

namespace Infrastructure.Seeders
{
    public class UserConstants
    {
        public static List<User> Users = new()
        {
            new User() { Username = "abhi", EmailAddress = "jason.admin@email.com", Password = "abhi", GivenName = "Jason", Surname = "Bryant", Role = "Administrator" },
            new User() { Username = "elyse_seller", EmailAddress = "elyse.seller@email.com", Password = "MyPass_w0rd", GivenName = "Elyse", Surname = "Lambert", Role = "Seller" },
        };
    }
}
