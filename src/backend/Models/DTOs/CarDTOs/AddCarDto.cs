using System.ComponentModel.DataAnnotations;
using Models.CustomValidations;
using Models.Enums;

namespace Models.DTOs.CarDTOs;

public record AddCarDto
{
    [Required]
    public Guid CarBrandId { get; set; }
    
    [Required]
    public Guid CarModelId { get; set; }
    
    [Required]
    public Guid ClientId { get; set; }
    
    [Required]
    public DateTime ManufactureDate { get; set; }
    
    /// <summary>
    /// Mechanics = 1,
    /// Auto = 2,
    /// Variator = 3
    /// </summary>
    [Required]
    [ValidTransmissionType]
    public TransmissionType TransmissionType { get; set; }
    
    /// <summary>
    /// EnginePower in kilowatts
    /// </summary>
    public double EnginePower { get; set; }
}
