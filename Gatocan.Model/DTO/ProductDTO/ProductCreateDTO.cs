using System.ComponentModel.DataAnnotations;

namespace Gatocan.Models;


public class ProductCreateDTO
{
    [Required]
    public string? Name { get; set; }
    [Required]
    public string? Description { get; set; }
    [Required]
    public double Price { get; set; }
    [Required]
    public string? Category { get; set; }
    [Required]
    public string? Brand { get; set; }
    [Required]
    public int Stock { get; set; }
    [Required]
    public string? ImageUrl { get; set; }
}