using System.Security.Claims;
using Gatocan.Model;

namespace Gatocan.Business;

    public interface IAuthService
    {
       
        public string GenerateJwtToken(User user);
        public bool HasAccessToResource(int requestedUserID, ClaimsPrincipal user);
    }
