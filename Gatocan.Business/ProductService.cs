using Gatocan.Data;
using Gatocan.Model;


namespace Gatocan.Business;
public class ProductService : IProductService
{

private readonly IProductRepository _repository;

public ProductService(IProductRepository repository)
{
_repository = repository;
}

public Product RegisterProduct( Product product){
 try
 {
    product= new(product.Name,product.Description, product.Price, product.Category, product.Brand, product.Stock, product.ImageUrl);
    _repository.AddProduct(product);
    _repository.SaveChanges();
    return product;
 }   
 catch(Exception e){
    
    throw new Exception("An error ocurred registering the Product", e);
 }
}

public  IEnumerable<Product> GetAllProducts(){
   
  return _repository.GetAllProducts();
}

 public Product GetProductById(int productId){
        try{
            return _repository.GetProductById(productId);
        }
        catch(Exception e){
            
            throw new Exception("An error has ocurred getting the product", e);
        }
    }

public Product GetProductByName(string name){
        try{
            return _repository.GetProductByName(name);
        }
        catch(Exception e){
            
            throw new Exception("An error has ocurred getting the product", e);
        }
    }

public void DeleteProduct(int productId){
         
try{
Product getProduct = GetProductById(productId);

if (getProduct != null){
_repository.DeleteProduct(getProduct);
_repository.SaveChanges();
Console.WriteLine("Product has been removed");
}else{
Console.WriteLine("No product found");
}
}catch(Exception e ){
            
throw new Exception("An error ocurred deleting the product", e);
}
}
public void UpdateProduct(int productId,  Product newProduct){
    
var product = _repository.GetProductById(productId);
if (product==null){
throw new KeyNotFoundException($"Product with ID {productId} wasnt found");
}
product.Name= newProduct.Name;
product.Description=newProduct.Description;
product.Price=newProduct.Price;
product.Category= newProduct.Category;
product.Brand= newProduct.Brand;
product.Stock=newProduct.Stock;
product.ImageUrl= newProduct.ImageUrl;
_repository.UpdateProduct(product);
_repository.SaveChanges();
}

}