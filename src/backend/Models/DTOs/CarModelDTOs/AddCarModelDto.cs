using System.ComponentModel.DataAnnotations;

namespace Models.DTOs.CarModelDTOs;

public record AddCarModelDto
{
    [Required]
    public Guid BrandId { get; set; }

    [Required]
    public string Name { get; set; }
}
