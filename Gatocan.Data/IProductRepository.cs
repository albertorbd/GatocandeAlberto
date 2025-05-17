using Gatocan.Model;

namespace Gatocan.Data;

public interface IProductRepository{

void AddProduct(Product product);
 IQueryable<Product> GetAllProducts(); 
Product GetProductByName(string name);
Product GetProductById(int id);
void DeleteProduct(Product product);
void UpdateProduct (Product product);
void SaveChanges();
    
}
