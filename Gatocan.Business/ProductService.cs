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
}