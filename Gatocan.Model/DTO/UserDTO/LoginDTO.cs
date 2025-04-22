using System.ComponentModel.DataAnnotations;

namespace Gatocan.Model;

public class LoginDTO
{   
    [Required(ErrorMessage = "email is required.")]
    public string? Email { get; set; }

    [Required(ErrorMessage = "Password is required.")]
    [MinLength(3, ErrorMessage = "Password need to have almost 3 Characters.")]
    public string? Password { get; set; }
}