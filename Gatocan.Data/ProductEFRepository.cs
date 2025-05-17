using Gatocan.Model;
using Microsoft.EntityFrameworkCore;

namespace Gatocan.Data
{
    public class ProductEFRepository : IProductRepository
    {
        private readonly GatocanContext _context;

        public ProductEFRepository(GatocanContext context)
        {
            _context = context;
        }
         public void AddProduct(Product product)
        {
            _context.Products.Add(product);
            SaveChanges();
        }
        
        public IQueryable<Product> GetAllProducts() 
        {
           return _context.Products;
        }

        public Product GetProductByName(string productName)
        {
            var product = _context.Products.FirstOrDefault(product => product.Name == productName);
            return product;
        }
        public Product GetProductById(int ProductId)
        {
            var product = _context.Products.FirstOrDefault(product => product.Id == ProductId);
            return product;
        }


        public void UpdateProduct(Product product)
        {
            _context.Entry(product).State = EntityState.Modified;
            SaveChanges();
        }

        public void DeleteProduct(Product productDelete) {
            var product = GetProductById(productDelete.Id);
            _context.Products.Remove(product);
            SaveChanges();
        }




         public void SaveChanges()
        {
            _context.SaveChanges();
        }

    }
    

}