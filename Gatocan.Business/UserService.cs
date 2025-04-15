using Gatocan.Data;
using Gatocan.Model;
using Gatocan.Models;


namespace Gatocan.Business;
public class UserService : IUserService
{

private readonly IUserRepository _repository;

public UserService(IUserRepository repository)
{
_repository = repository;
}
public User RegisterUser(UserCreateDTO userCreateDTO){

try
 {
User user= new(userCreateDTO.Name, userCreateDTO.Lastname, userCreateDTO.Email, userCreateDTO.Password);
_repository.AddUser(user);

return user;
 }   
 catch(Exception e){
    
throw new Exception("An error ocurred registering the user", e);
 }    
}
public  IEnumerable<User> GetAllUsers(){
   
  return _repository.GetAllUsers();
}

public bool CheckRepeatUser(string email){
try
    {
foreach (var user in _repository.GetAllUsers())
{
if (user.Email.Equals(email, StringComparison.OrdinalIgnoreCase))
{
return true;
}
}
return false;
}
catch (Exception e)
{
            
throw new Exception("An error has ocurred checking user", e);
}
}

public User GetUserByEmail(string email){
        try{
            return _repository.GetUserByEmail(email);
        }
        catch(Exception e){
           
            throw new Exception("An error has ocurred getting the user", e);
        }
    }

 public User GetUserById(int idUser){
try{
return _repository.GetUserById(idUser);
}
catch(Exception e){
           
throw new Exception("An error has ocurred getting the user", e);
}
}   
public void DeleteUser(int userId){
         
try{
User getUser = GetUserById(userId);

if (getUser != null){
_repository.DeleteUser(getUser);
_repository.SaveChanges();
Console.WriteLine("User has been removed");
}else{
Console.WriteLine("No user found");
}
}catch(Exception e ){
            
throw new Exception("An error ocurred deleting the user", e);
}
}

 public void UpdateUser(int userId, UserUpdateDTO userUpdateDTO){
    
var user = _repository.GetUserById(userId);
if (user==null){
throw new KeyNotFoundException($"User with ID {userId} wasnt found");
}
user.Name= userUpdateDTO.Name;
user.Email= userUpdateDTO.Email;
user.Password= userUpdateDTO.Password;
_repository.UpdateUser(user);
_repository.SaveChanges();
}

  



}
