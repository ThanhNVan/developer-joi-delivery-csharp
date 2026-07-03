using JoiDelivery.Interfaces;
using JoiDelivery.Models;
using JoiDelivery.Seed;

namespace JoiDelivery.Services;

public class UserService : IUserService
{
    private readonly List<User> _users = SeedData.Users;

    public User? FetchUserById(string userId) => _users.FirstOrDefault(user => user.Id == userId);
}
