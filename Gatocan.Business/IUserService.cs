using Gatocan.Model;
using Gatocan.Models;

namespace Gatocan.Business;

public interface IUserService{
 User RegisterUser(UserCreateDTO userCreateDTO);
IEnumerable<User> GetAllUsers();  
bool CheckRepeatUser(string email);
User GetUserByEmail(string email);
User GetUserById(int userId);
void DeleteUser(int userId);
void UpdateUser(int userId, UserUpdateDTO userUpdateDTO);
   
}