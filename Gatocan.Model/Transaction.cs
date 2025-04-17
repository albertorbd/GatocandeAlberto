namespace Gatocan.Model;

public enum TransactionType
{
    Ingreso,
    Compra
}
public class Transaction{

public int Id { get; set; }         
public int UserId { get; set; }      
public User User { get; set; }       
public int? ProductId { get; set; }   
public Product Product { get; set; }      
public double Amount { get; set; }   
public int Quantity { get; set; }   
public DateTime Date { get; set; }  
public string PaymentMethod { get; set; }
public TransactionType Tipo { get; set; }



public Transaction(){}

public Transaction(int userId, int productId, double amount, int quantity, string paymentMethod, TransactionType tipo)
    {
        UserId = userId;
        ProductId = productId;
        Amount = amount;
        Quantity = quantity;
        PaymentMethod = paymentMethod;
        Tipo = tipo;
        Date = DateTime.Now; 
    }
}