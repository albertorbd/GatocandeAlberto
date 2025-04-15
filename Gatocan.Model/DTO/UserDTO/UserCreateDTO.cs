using System.ComponentModel.DataAnnotations;

namespace Gatocan.Models;

public class UserCreateDTO
{   
    [Required]
    public string? Name { get; set; }
    [Required]
    public string? Lastname { get; set; }
    [Required]
    public string? Email { get; set; }
     [Required]
    public string? Password { get; set; }
   
  

}