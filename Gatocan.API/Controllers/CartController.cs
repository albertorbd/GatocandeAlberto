using Gatocan.Business;
using Gatocan.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;


namespace Gatocan.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;
        private readonly IAuthService _authService;

        public CartController(ICartService cartService, IAuthService authService)
        {
            _cartService = cartService;
            _authService= authService;
        }

        [Authorize(Roles = Roles.Admin + "," + Roles.User)]
        [HttpGet("{userId}")]
        public ActionResult<Cart> GetCart(int userId)
        {
            
               if (!_authService.HasAccessToResource(userId, User))
                return Forbid();        


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

         [Authorize(Roles = Roles.Admin + "," + Roles.User)]
        [HttpPost("{userId}/add")]
        public IActionResult AddProductToCart(int userId, [FromBody] CartItemDto itemDto)
        {
             if (!_authService.HasAccessToResource(userId, User))
                return Forbid();   
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

        [Authorize(Roles = Roles.Admin + "," + Roles.User)]
        [HttpPut("{userId}/update")]
        public IActionResult UpdateProductQuantity(int userId, [FromBody] CartItemDto itemDto)
        {
             if (!_authService.HasAccessToResource(userId, User))
                return Forbid();   
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

        [Authorize(Roles = Roles.Admin + "," + Roles.User)]
        [HttpDelete("{userId}/remove/{productId}")]
        public IActionResult RemoveProductFromCart(int userId, int productId)
        {
            if (!_authService.HasAccessToResource(userId, User))
                return Forbid();  
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

        [Authorize(Roles = Roles.Admin + "," + Roles.User)]
        [HttpDelete("{userId}/clear")]
        public IActionResult ClearCart(int userId)
        {

            if (!_authService.HasAccessToResource(userId, User))
                return Forbid();  
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
