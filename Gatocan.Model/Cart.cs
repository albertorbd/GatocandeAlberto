namespace Gatocan.Model;

 public class Cart
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; } 
        public List<CartItem> Items { get; set; }
        public DateTime DateCreated { get; set; }

 
        public Cart()
        {
            Items = new List<CartItem>();
            DateCreated = DateTime.Now;
        }

      
        public Cart(int userId, User user)
        {
            UserId = userId;
            User = user;
            Items = new List<CartItem>();
            DateCreated = DateTime.Now;
        }
    }

    public class CartItem
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }

        public CartItem(int productId, int quantity)
        {
            ProductId = productId;
            Quantity = quantity;
            
        }
    }



