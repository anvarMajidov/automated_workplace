namespace Models.DTOs.CarModelDTOs;

public record CarModelDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }

    public Guid BrandId { get; set; }
}
