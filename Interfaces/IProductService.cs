using JoiDelivery.Models;

namespace JoiDelivery.Interfaces;

public interface IProductService
{
    GroceryProduct? GetProduct(string productId, string outletId);
}
