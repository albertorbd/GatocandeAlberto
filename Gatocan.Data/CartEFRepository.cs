using Gatocan.Model;
using Microsoft.EntityFrameworkCore;


namespace Gatocan.Data;

    public class CartEFRepository : ICartRepository
    {
        private readonly GatocanContext _context;

        public CartEFRepository(GatocanContext context)
        {
            _context = context;
        }

public Cart GetCartByUserId(int userId)
{
    var cart = _context.Carts
        .Include(c => c.Items)
        .ThenInclude(i => i.Product)
        .FirstOrDefault(c => c.UserId == userId);

    if (cart == null)
    {
        var user = _context.Users.Find(userId);
        if (user == null)
        {
            throw new Exception($"El usuario con ID {userId} no existe.");
        }

        cart = new Cart(userId, user);
        _context.Carts.Add(cart);
        _context.SaveChanges();
    }

    return cart;
}
        public void AddItemToCart(int cartId, CartItem item)
        {
            var cart = _context.Carts.Include(c => c.Items).FirstOrDefault(c => c.Id == cartId);
            if (cart != null)
            {
                // Si el item ya existe, suma la cantidad
                var existingItem = cart.Items.FirstOrDefault(i => i.ProductId == item.ProductId);
                if (existingItem != null)
                    existingItem.Quantity += item.Quantity;
                else
                    cart.Items.Add(item);
                SaveChanges();
            }
        }

        public void UpdateItemQuantity(int cartId, int productId, int newQuantity)
        {
            var cart = _context.Carts.Include(c => c.Items).FirstOrDefault(c => c.Id == cartId);
            if (cart != null)
            {
                var item = cart.Items.FirstOrDefault(i => i.ProductId == productId);
                if (item != null)
                {
                    if (newQuantity <= 0)
                        cart.Items.Remove(item);
                    else
                        item.Quantity = newQuantity;
                    SaveChanges();
                }
            }
        }

        public void RemoveItemFromCart(int cartId, int productId)
        {
            var cart = _context.Carts.Include(c => c.Items).FirstOrDefault(c => c.Id == cartId);
            if (cart != null)
            {
                var item = cart.Items.FirstOrDefault(i => i.ProductId == productId);
                if (item != null)
                {
                    cart.Items.Remove(item);
                    SaveChanges();
                }
            }
        }

        public void ClearCart(int cartId)
        {
            var cart = _context.Carts.Include(c => c.Items).FirstOrDefault(c => c.Id == cartId);
            if (cart != null)
            {
                cart.Items.Clear();
                SaveChanges();
            }
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
