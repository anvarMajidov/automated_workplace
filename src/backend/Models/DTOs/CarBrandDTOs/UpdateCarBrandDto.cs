using System.ComponentModel.DataAnnotations;

namespace Models.DTOs.CarBrandDTOs;

public record UpdateCarBrandDto
{
    [Required]
    public Guid Id { get; set; }
    
    [Required]
    public string Name { get; set; }
}
