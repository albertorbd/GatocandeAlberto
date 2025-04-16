using Gatocan.Model;


namespace Gatocan.Data;

    public interface ICartRepository
    {
        
        Cart GetCartByUserId(int userId);
        void AddItemToCart(int cartId, CartItem item);
        void UpdateItemQuantity(int cartId, int productId, int newQuantity);
        void RemoveItemFromCart(int cartId, int productId);
        void ClearCart(int cartId);
        void SaveChanges();
    }
