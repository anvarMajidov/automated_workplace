using Models.DbModels;
using Models.Enums;

namespace Models.DTOs.CarDTOs;

public record CarDto
{
    public Guid CarBrandId { get; set; }
    public string CarBrandName { get; set; }
    
    public Guid CarModelId { get; set; }
    public string CarModelName { get; set; }

    public Guid ClientId { get; set; }
    
    public DateTime ManufactureDate { get; set; }
    
    public TransmissionType TransmissionType { get; set; }
    
    //EnginePower in kilowatts
    public double EnginePower { get; set; }
}
