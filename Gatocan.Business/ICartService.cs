using Gatocan.Model;


namespace Gatocan.Business;

    public interface ICartService
    {
        // Obtiene el carrito del usuario, creándolo automáticamente si no existe
        Cart GetCartByUserId(int userId);
        void AddProductToCart(int userId, int productId, int quantity);
        void UpdateProductQuantityInCart(int userId, int productId, int newQuantity);
        void RemoveProductFromCart(int userId, int productId);
        void ClearUserCart(int userId);
    }
