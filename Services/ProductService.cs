using JoiDelivery.Interfaces;
using JoiDelivery.Models;
using JoiDelivery.Seed;

namespace JoiDelivery.Services;

public class ProductService : IProductService
{
    private readonly List<GroceryProduct> _products = SeedData.GroceryProducts;

    public GroceryProduct? GetProduct(string productId, string outletId) =>
        _products.FirstOrDefault(p =>
            p.Id == productId && p.Store?.Id == outletId);
}