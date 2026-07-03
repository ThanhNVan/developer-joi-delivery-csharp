using JoiDelivery.Dtos;
using JoiDelivery.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace JoiDelivery.Controllers;

[ApiController]
[Route("[controller]")]
public class CartController(ICartService cartService) : ControllerBase
{
    [HttpPost("product")]
    public async ValueTask<IActionResult> AddProductToCart([FromBody] AddProductRequest addProductRequest)
    {
        try
        {
            var result = cartService.AddProductToCartForUser(addProductRequest);

            return Ok(result);
        }
        catch (UnauthorizedAccessException e)
        {
            Console.WriteLine(e);
            return Unauthorized(e.Message);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return BadRequest(e.Message);
        }
    }

    [HttpGet("view")]
    public async ValueTask<IActionResult> ViewCart([FromQuery(Name = "userId")] string userId)
    {
        var cart = cartService.GetCartForUser(userId);
        return Ok(cart);
    }
}
