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
    }
    

}