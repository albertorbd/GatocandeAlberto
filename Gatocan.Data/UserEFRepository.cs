using Gatocan.Model;
using Microsoft.EntityFrameworkCore;

namespace Gatocan.Data
{
    public class UserEFRepository : IUserRepository
    {
        private readonly GatocanContext _context;

        public UserEFRepository(GatocanContext context)
        {
            _context = context;
        }
    }

}