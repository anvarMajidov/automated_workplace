using System.ComponentModel.DataAnnotations;

namespace Models.DTOs.ClientDTOs;

public record AddClientDto
{
    [Required]
    public string Name { get; set; }
    
    [Required]
    public string Surname { get; set; }
    
    public string? Patronymic { get; set; }
    
    [Required]
    [RegularExpression(@"^[\+]?[(]?\d{3}[)]?[-\s\.]?\d{3}[-\s\.]?\d{4,6}$")]
    public string Phone { get; set; }
}
