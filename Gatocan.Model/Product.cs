namespace Gatocan.Model;
using System.ComponentModel.DataAnnotations;

 public class Product
    {
[Key]
public int Id { get; set; }
[Required]     
public string Name { get; set; } 
[Required] 
public string Description { get; set; }
[Required] 
public double Price { get; set; }
[Required]   
public string Category { get; set; }
[Required] 
public string Brand { get; set; }
[Required]  
public int Stock { get; set; }
[Required]     
public string ImageUrl { get; set; } 
    

public Product(){}


public Product(string name, string description, double price, string category, string brand, int stock, string imageUrl){
Name= name;
Description= description;
Price= price;
Category= category;
Brand= brand;
Stock= stock;
ImageUrl= imageUrl;
}
}