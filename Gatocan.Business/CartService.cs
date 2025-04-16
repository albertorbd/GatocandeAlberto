using Gatocan.Data;
using Gatocan.Model;


namespace Gatocan.Business;

    public class CartService : ICartService
    {
        private readonly ICartRepository _cartRepository;

        public CartService(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        public Cart GetCartByUserId(int userId)
        {
            try
            {
                return _cartRepository.GetCartByUserId(userId);
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while retrieving the cart for user ID {userId}.", ex);
            }
        }       
         public void AddProductToCart(int userId, int productId, int quantity)
        {
            try
            {
                var cart = _cartRepository.GetCartByUserId(userId);
                var newItem = new CartItem(productId, quantity);
                _cartRepository.AddItemToCart(cart.Id, newItem);
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while adding product ID {productId} to the cart for user ID {userId}.", ex);
            }
        }

       public void UpdateProductQuantityInCart(int userId, int productId, int newQuantity)
        {
            try
            {
                var cart = _cartRepository.GetCartByUserId(userId);
                _cartRepository.UpdateItemQuantity(cart.Id, productId, newQuantity);
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while updating the quantity of product ID {productId} in the cart for user ID {userId}.", ex);
            }
        }
       public void RemoveProductFromCart(int userId, int productId)
        {
            try
            {
                var cart = _cartRepository.GetCartByUserId(userId);
                _cartRepository.RemoveItemFromCart(cart.Id, productId);
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while removing product ID {productId} from the cart for user ID {userId}.", ex);
            }
        }

        public void ClearUserCart(int userId)
        {
            try
            {
                var cart = _cartRepository.GetCartByUserId(userId);
                _cartRepository.ClearCart(cart.Id);
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while clearing the cart for user ID {userId}.", ex);
            }
        }
    }
    
