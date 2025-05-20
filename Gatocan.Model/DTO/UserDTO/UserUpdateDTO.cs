using System.ComponentModel.DataAnnotations;

namespace Gatocan.Model;

public class UserUpdateDTO
{
  [StringLength(100, MinimumLength = 2, ErrorMessage = "El nombre debe tener entre 2 y 100 caracteres.")]
  public string? Name { get; set; }

  [EmailAddress(ErrorMessage = "Formato de correo no válido.")]
  public string? Email { get; set; }

  [StringLength(100, MinimumLength = 6, ErrorMessage = "La contraseña debe tener al menos 6 caracteres.")]
  public string? Password { get; set; }

  [StringLength(9, MinimumLength = 9, ErrorMessage = "El teléfono debe tener exactamente 9 dígitos.")]
  [RegularExpression(@"^\d+$", ErrorMessage = "Solo se permiten números.")]
  public string? Phone { get; set; }

  public string? Address { get; set; }
}