using JoiDelivery.Dtos;
using JoiDelivery.Interfaces;
using JoiDelivery.Models;
using JoiDelivery.Seed;

namespace JoiDelivery.Services;

public class CartService(IProductService productService, IUserService userService)
: ICartService
{
    private readonly Dictionary<string, Cart> _userCarts = SeedData.CartForUsers;

    public CartProductInfo AddProductToCartForUser(AddProductRequest addProductRequest)
    {
        var user = userService.FetchUserById(addProductRequest.UserId);

        if (user is null)
            throw new UnauthorizedAccessException($"Cannot find the User: {addProductRequest.UserId}");

        var cart = FetchCartForUser(user);
        var product = productService.GetProduct(addProductRequest.ProductId, addProductRequest.OutletId);

        cart ??= new Cart();

        if (product is null)
            throw new KeyNotFoundException($"Cannot find the Product: {addProductRequest.ProductId}");

        cart.Products.Add(product);

        return new CartProductInfo(cart, product, product.SellingPrice);
    }
    
    public Cart? GetCartForUser(string userId) => 
        _userCarts.GetValueOrDefault(userId);
    
    private Cart? FetchCartForUser(User user) =>
        _userCarts.GetValueOrDefault(user.Id);
}