namespace Gatocan.Model;

  public class DepositDto
    {
        public int UserId { get; set; }
        public double Amount { get; set; }
        public string PaymentMethod { get; set; } = "Card";
    }
