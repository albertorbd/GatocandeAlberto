using System.ComponentModel.DataAnnotations;

namespace Gatocan.Model;

public class UserCreateDTO
{   
    [Required]
    public string? Name { get; set; }
    [Required]
    public string? Lastname { get; set; }
    [Required]
    [EmailAddress(ErrorMessage = "Formato de correo no válido.")]
    public string? Email { get; set; }
    [Required]
    [StringLength(100, MinimumLength = 5, ErrorMessage = "La contraseña debe tener al menos 6 caracteres.")]
    public string? Password { get; set; }
   
  

}