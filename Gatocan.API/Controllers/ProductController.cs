using Microsoft.AspNetCore.Mvc;
using Gatocan.Business;
using Gatocan.Model;
using Gatocan.Models;



namespace Gatocan.API.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{
    private readonly ILogger<ProductController> _logger;
    private readonly IProductService _productService;

  public ProductController(ILogger<ProductController> logger, IProductService productService)
    {
        _logger = logger;
        _productService = productService;
          
    }
[HttpGet]
    public ActionResult<IEnumerable<Product>> GetAllProducts()
    {
        try 
        {
            var products = _productService.GetAllProducts();
            return Ok(products);
        }     
        catch (Exception ex)
        {
            _logger.LogError($"An error has ocurred trying to get the products. {ex.Message}");
            return BadRequest($"An error has ocurred trying to get the products. {ex.Message}");
        }
    }

[HttpGet("byName", Name = "GetProductByName")]
    public IActionResult GetProductByName(string name)
    {
        
        try
        {
            var product = _productService.GetProductByName(name);
            return Ok(product);
        }
        catch (KeyNotFoundException knfex)
        {
            _logger.LogWarning($"Couldnt find the product with name: {name}. {knfex.Message}");
           return NotFound($"Couldnt find the product with name: {name}. {knfex.Message}");
        }
        catch (Exception ex)
        {
            _logger.LogError($"An error has ocurred trying to get the product with name: {name}. {ex.Message}");
            return BadRequest($"An error has ocurred trying to get the product with name: {name}. {ex.Message}");
        }
    }

 [HttpGet("{productId}", Name = "GetProductById") ]
    public IActionResult GetProductById(int productId)
    {
        
        try
        {
            var product = _productService.GetProductById(productId);
            return Ok(product);
        }
        catch (KeyNotFoundException knfex)
        {
            _logger.LogWarning($"Couldnt find the product with id: {productId}. {knfex.Message}");
            return NotFound($"Couldnt find the product with id: {productId}. {knfex.Message}");
        }
        catch (Exception ex)
        {
            _logger.LogError($"An error has ocurred trying to get the product with id: {productId}. {ex.Message}");
            return BadRequest($"An error has ocurred trying to get the product with id: {productId}. {ex.Message}");
        }
    }
[HttpPut("{productId}")]
   public IActionResult UpdateProduct(int productId, [FromBody] ProductUpdateDTO productUpdate)
    {
        if (!ModelState.IsValid)  {return BadRequest(ModelState); } 
        
        try
        {
            _productService.UpdateProduct(productId, productUpdate);
            return Ok($"The product with id: {productId} has been updated correctly");
        }
         catch (KeyNotFoundException knfex)
        {
            _logger.LogWarning($"Couldnt find the product with id: {productId}. {knfex.Message}");
            return NotFound($"Couldnt find the product with id: {productId}. {knfex.Message}");
        }
        catch (Exception ex)
        {
            _logger.LogError($"An error has ocurred trying to update product with id: {productId}. {ex.Message}");
            return BadRequest($"An error has ocurred trying to update user with id: {productId}. {ex.Message}");
        }
    }

 [HttpDelete("{productId}")]
    public IActionResult DeleteProduct(int productId)
    {
        try
        {
            _productService.DeleteProduct(productId);
            return Ok($"El producto con id {productId} ha sido eliminado ");
        }
        catch (KeyNotFoundException knfex)
        {
            _logger.LogWarning($"Couldnt find the product with id: {productId}. {knfex.Message}");
            return NotFound($"Couldnt find the product with id: {productId}. {knfex.Message}");
        }
        catch (Exception ex)
        {
            _logger.LogError($"An error has ocurred trying to delete product with id: {productId}. {ex.Message}");
            return BadRequest($"An error has ocurred trying to delete product with id: {productId}. {ex.Message}");
        }
    }

 [HttpPost]
    public IActionResult CreateProduct([FromBody] ProductCreateDTO productCreate)
    {
        try 
        {
            // Verificar si el modelo recibido es válido
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var productExist = _productService.GetProductByName(productCreate.Name);
            if (productExist != null)
            {
                return BadRequest("El producto ya está registrado.");
            }

            var product = _productService.RegisterProduct(productCreate);

           
            return CreatedAtAction(nameof(GetAllProducts), new { productId = product.Id }, productCreate);
        }     
          catch (Exception ex)
        {
            _logger.LogError($"An error has ocurred trying to register the product. {ex.Message}");
            return BadRequest($"An error has ocurred trying to register the product. {ex.Message}");
        }
        
    }

  


}
