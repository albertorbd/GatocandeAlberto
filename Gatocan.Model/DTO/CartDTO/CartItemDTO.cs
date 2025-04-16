 
 using System.ComponentModel.DataAnnotations;

namespace Gatocan.Models;


  public class CartItemDto
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
