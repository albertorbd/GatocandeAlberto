namespace Gatocan.Model;

public class PurchaseDto
    {
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public string PaymentMethod { get; set; }
    }