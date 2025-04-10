using Gatocan.Model;

namespace Gatocan.Business;

public interface IUserService{
 User RegisterUser(User user);
IEnumerable<User> GetAllUsers();  
bool CheckRepeatUser(string email);
User GetUserByEmail(string email);
User GetUserById(int userId);
void DeleteUser(int userId);
void UpdateUser(int userId, User newUser);
   
}