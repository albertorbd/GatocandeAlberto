using Gatocan.Model;


namespace Gatocan.Business;

public interface IProductService{
Product RegisterProduct(ProductCreateDTO productCreateDTO);
IEnumerable<Product> GetFilteredProducts(
    string? search,
    string[]? brands,
    string[]? categories,
    string? priceOrder
);
IEnumerable<Product> GetAllProducts();  
Product GetProductById(int productId);
Product GetProductByName(string name);
void DeleteProduct(int productId);
void UpdateProduct(int productId, ProductUpdateDTO productUpdateDTO);   
}