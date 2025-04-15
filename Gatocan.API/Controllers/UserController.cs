using Microsoft.AspNetCore.Mvc;
using Gatocan.Business;
using Gatocan.Model;
using Gatocan.Models;



namespace Gatocan.API.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly ILogger<UserController> _logger;
    private readonly IUserService _userService;

  public UserController(ILogger<UserController> logger, IUserService userService)
    {
        _logger = logger;
        _userService = userService;
          
    }

 [HttpGet]
    public ActionResult<IEnumerable<User>> GetAllUsers()
    {
        try 
        {
            var users = _userService.GetAllUsers();
            return Ok(users);
        }     
        catch (Exception ex)
        {
            _logger.LogError($"An error has ocurred trying to get the users. {ex.Message}");
            return BadRequest($"An error has ocurred trying to get the users. {ex.Message}");
        }
    }

[HttpGet("byEmail", Name = "GetUserByEmail")]
    public IActionResult GetUserByEmail(string email)
    {
        
        try
        {
            var user = _userService.GetUserByEmail(email);
            return Ok(user);
        }
        catch (KeyNotFoundException knfex)
        {
            _logger.LogWarning($"Couldnt find the user with email: {email}. {knfex.Message}");
           return NotFound($"Couldnt find the user with email: {email}. {knfex.Message}");
        }
        catch (Exception ex)
        {
            _logger.LogError($"An error has ocurred trying to get the user with email: {email}. {ex.Message}");
            return BadRequest($"An error has ocurred trying to get the user with email: {email}. {ex.Message}");
        }
    }

 [HttpGet("{userId}", Name = "GetUserById") ]
    public IActionResult GetUserById(int userId)
    {
        
        try
        {
            var user = _userService.GetUserById(userId);
            return Ok(user);
        }
        catch (KeyNotFoundException knfex)
        {
            _logger.LogWarning($"Couldnt find the user with id: {userId}. {knfex.Message}");
            return NotFound($"Couldnt find the user with id: {userId}. {knfex.Message}");
        }
        catch (Exception ex)
        {
            _logger.LogError($"An error has ocurred trying to get the user with id: {userId}. {ex.Message}");
            return BadRequest($"An error has ocurred trying to get the user with id: {userId}. {ex.Message}");
        }
    }

       [HttpPut("{userId}")]

    public IActionResult UpdateUser(int userId, [FromBody] UserUpdateDTO userUpdate)
    {
        if (!ModelState.IsValid)  {return BadRequest(ModelState); } 
        
        try
        {
            _userService.UpdateUser(userId, userUpdate);
            return Ok($"The user with id: {userId} has been updated correctly");
        }
         catch (KeyNotFoundException knfex)
        {
            _logger.LogWarning($"Couldnt find the user with id: {userId}. {knfex.Message}");
            return NotFound($"Couldnt find the user with id: {userId}. {knfex.Message}");
        }
        catch (Exception ex)
        {
            _logger.LogError($"An error has ocurred trying to update user with id: {userId}. {ex.Message}");
            return BadRequest($"An error has ocurred trying to update user with id: {userId}. {ex.Message}");
        }
    }

 [HttpDelete("{userId}")]
    public IActionResult DeleteUser(int userId)
    {
        try
        {
            _userService.DeleteUser(userId);
            return Ok($"El usuario con id {userId} ha sido eliminado ");
        }
        catch (KeyNotFoundException knfex)
        {
            _logger.LogWarning($"Couldnt find the user with id:: {userId}. {knfex.Message}");
            return NotFound($"Couldnt find the user with id:: {userId}. {knfex.Message}");
        }
        catch (Exception ex)
        {
            _logger.LogError($"An error has ocurred trying to delete user with id: {userId}. {ex.Message}");
            return BadRequest($"An error has ocurred trying to delete user with id: {userId}. {ex.Message}");
        }
    }

     [HttpPost]
    public IActionResult CreateUser([FromBody] UserCreateDTO userCreate)
    {
        try 
        {
            // Verificar si el modelo recibido es válido
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userExist = _userService.GetUserByEmail(userCreate.Email);
            if (userExist != null)
            {
                return BadRequest("El usuario ya está registrado.");
            }

            var user = _userService.RegisterUser(userCreate);

           
            return CreatedAtAction(nameof(GetAllUsers), new { userId = user.Id }, userCreate);
        }     
          catch (Exception ex)
        {
            _logger.LogError($"An error has ocurred trying to register the user. {ex.Message}");
            return BadRequest($"An error has ocurred trying to register the user. {ex.Message}");
        }
        
    }


}