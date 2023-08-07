using System.ComponentModel.DataAnnotations;

namespace Models.DTOs.CarBrandDTOs;

public record AddCarBrandDto
{
    [Required] 
    public string Name { get; set; }
}
