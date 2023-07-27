using Models.Enums;

namespace Models.DbModels;

public class Car : BaseEntity
{
    public Guid CarBrandId { get; set; }
    public CarBrand CarBrand { get; set; }
    
    public Guid CarModelId { get; set; }
    public CarModel CarModel { get; set; }
    
    public Guid ClientId { get; set; }
    public Client Client { get; set; }
    
    public DateTime ManufactureDate { get; set; }
    
    public TransmissionType TransmissionType { get; set; }
    
    //EnginePower in kilowatts
    public double EnginePower { get; set; }
}
