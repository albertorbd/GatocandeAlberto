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

 public void UpdateUser(int userId, UserUpdateDTO userUpdateDTO)
{
    var user = _repository.GetUserById(userId);
    if (user == null)
    {
        throw new KeyNotFoundException($"User with ID {userId} wasn't found");
    }

    if (!string.IsNullOrEmpty(userUpdateDTO.Name))
    {
        user.Name = userUpdateDTO.Name;
    }
   if (!string.IsNullOrEmpty(userUpdateDTO.Email) && userUpdateDTO.Email != user.Email)
{
    if (IsEmailTaken(userUpdateDTO.Email))
    {
        throw new InvalidOperationException("El correo electrónico proporcionado ya está en uso por otra cuenta.");
    }
    user.Email = userUpdateDTO.Email;
    }
    if (!string.IsNullOrEmpty(userUpdateDTO.Password))
    {
        user.Password = userUpdateDTO.Password;
    }
    if (!string.IsNullOrEmpty(userUpdateDTO.Phone))
    {
        user.Phone = userUpdateDTO.Phone;
    }
    if (!string.IsNullOrEmpty(userUpdateDTO.Address))
    {
        user.Address = userUpdateDTO.Address;
    }

    _repository.UpdateUser(user);
    _repository.SaveChanges();
}

public bool IsEmailTaken(string email){
        try{
            var users= _repository.GetAllUsers();
            foreach(var user in users){
                if(user.Email==email){
                    return true;
                }
            }
            return false;
        }catch (Exception e)
        {
            
            throw new Exception("An error has ocurred checking if email is in use", e);
        }

        }
   

    
    
public User loginCheck(string email, string password)
{
    if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
    {
        throw new ArgumentException("Email and password are obligatory.");
    }

    foreach (var userToLog in _repository.GetAllUsers())
    {
        if (userToLog.Email.Equals(email, StringComparison.OrdinalIgnoreCase) &&
            userToLog.Password.Equals(password))
        {
            return userToLog;
        }
    }
    return null;
}  



}
