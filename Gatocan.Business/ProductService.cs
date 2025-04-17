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

public Product RegisterProduct( ProductCreateDTO productCreateDTO){
 try
 {
    Product product= new(productCreateDTO.Name,productCreateDTO.Description, productCreateDTO.Price, productCreateDTO.Category, productCreateDTO.Brand, productCreateDTO.Stock, productCreateDTO.ImageUrl);
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
public void UpdateProduct(int productId,  ProductUpdateDTO productUpdateDTO){
    
var product = _repository.GetProductById(productId);
if (product==null){
throw new KeyNotFoundException($"Product with ID {productId} wasnt found");
}
product.Name= productUpdateDTO.Name;
product.Description=productUpdateDTO.Description;
product.Price=productUpdateDTO.Price;
product.Category= productUpdateDTO.Category;
product.Brand= productUpdateDTO.Brand;
product.Stock=productUpdateDTO.Stock;
product.ImageUrl= productUpdateDTO.ImageUrl;
_repository.UpdateProduct(product);
_repository.SaveChanges();
}

}