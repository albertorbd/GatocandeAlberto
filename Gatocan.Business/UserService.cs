using Gatocan.Data;
using Gatocan.Model;


namespace Gatocan.Business;
public class UserService : IUserService
{

private readonly IUserRepository _repository;

    public UserService(IUserRepository repository)
    {
        _repository = repository;
    }
}
