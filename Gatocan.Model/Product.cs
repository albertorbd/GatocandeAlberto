namespace Gatocan.Model;

 public class Product
    {
        public int Id { get; set; }     
        public string Name { get; set; } 
        public string Description { get; set; }
        public double Price { get; set; }  
        public string Category { get; set; }
        public string Brand { get; set; } 
        public int Stock { get; set; }    
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