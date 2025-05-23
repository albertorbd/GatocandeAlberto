using Microsoft.AspNetCore.Mvc;
using Gatocan.Business;
using Gatocan.Model;

namespace GamedreamAPI.API.Controllers
{
    [ApiController]
   [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IAuthService _authService;
        private readonly ILogger<AuthController> _logger;


        public AuthController(IUserService userService, IAuthService authService, ILogger<AuthController> logger)
        {
            _logger=logger;
            _userService = userService;
            _authService=authService;
        }

         [HttpPost("register")]
    public IActionResult Register([FromBody] UserCreateDTO dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        try
        {
            
            if (_userService.GetUserByEmail(dto.Email) != null)
                return BadRequest("El usuario ya está registrado.");

            
            var user = _userService.RegisterUser(dto);

            
            var token = _authService.GenerateJwtToken(user);

            return Ok(new { user, token });
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error registrando usuario: {ex.Message}");
            return BadRequest($"Error registrando usuario: {ex.Message}");
        }
    }


        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginDTO loginDTO)
        {

        if (!ModelState.IsValid)
    {
        return BadRequest(ModelState);
    }
            try
        {
            var user = _userService.loginCheck(loginDTO.Email, loginDTO.Password);
            if (user != null)
            {
                var token = _authService.GenerateJwtToken(user);
                  return Ok(new { token });
            }
            else
            {
                return NotFound("No se ha encontrado ningún usuario con esas credenciales");
            }
        }
        catch (KeyNotFoundException knfex)
        {
            _logger.LogWarning($"No user found. {knfex.Message}");
           return NotFound($"No user found. {knfex.Message}");
        }
        catch (Exception ex)
        {
            _logger.LogError($"No user found. {ex.Message}");
            return BadRequest($"No user found. {ex.Message}");
        }
}

}
}