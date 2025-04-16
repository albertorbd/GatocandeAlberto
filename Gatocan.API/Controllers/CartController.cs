using Gatocan.Business;
using Gatocan.Model;
using Gatocan.Models;
using Microsoft.AspNetCore.Mvc;


namespace Gatocan.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;

        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        // GET: api/cart/{userId}
        [HttpGet("{userId}")]
        public ActionResult<Cart> GetCart(int userId)
        {
            try
            {
                var cart = _cartService.GetCartByUserId(userId);
                return Ok(cart);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while retrieving the cart: {ex.Message}");
            }
        }

        
        [HttpPost("{userId}/add")]
        public IActionResult AddProductToCart(int userId, [FromBody] CartItemDto itemDto)
        {
            try
            {
                _cartService.AddProductToCart(userId, itemDto.ProductId, itemDto.Quantity);
                return Ok("Product added to cart successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while adding the product to the cart: {ex.Message}");
            }
        }

       
        [HttpPut("{userId}/update")]
        public IActionResult UpdateProductQuantity(int userId, [FromBody] CartItemDto itemDto)
        {
            try
            {
                _cartService.UpdateProductQuantityInCart(userId, itemDto.ProductId, itemDto.Quantity);
                return Ok("Product quantity updated successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while updating the product quantity: {ex.Message}");
            }
        }

        
        [HttpDelete("{userId}/remove/{productId}")]
        public IActionResult RemoveProductFromCart(int userId, int productId)
        {
            try
            {
                _cartService.RemoveProductFromCart(userId, productId);
                return Ok("Product removed from cart successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while removing the product from the cart: {ex.Message}");
            }
        }

        
        [HttpDelete("{userId}/clear")]
        public IActionResult ClearCart(int userId)
        {
            try
            {
                _cartService.ClearUserCart(userId);
                return Ok("Cart cleared successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while clearing the cart: {ex.Message}");
            }
        }
    }
}
