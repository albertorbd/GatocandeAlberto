using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Gatocan.Model;

 public class Cart
    {  
    
        [Key]
        public int Id { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        [JsonIgnore]
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
        [Key]
        public int Id { get; set; }

         [ForeignKey("Product")]
        public int ProductId { get; set; }
        public int Quantity { get; set; }

        public Product Product { get; set; }
        
         [ForeignKey("Cart")]
         public int CartId { get; set; }  

        [JsonIgnore]
         public Cart Cart { get; set; }

         public CartItem() { }

        public CartItem(int productId, int quantity)
        {
            ProductId = productId;
            Quantity = quantity;
            
        }
    }



