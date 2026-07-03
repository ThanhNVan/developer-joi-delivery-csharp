using JoiDelivery.Models;

namespace JoiDelivery.Interfaces;

public interface IUserService
{
    User? FetchUserById(string userId);
}
