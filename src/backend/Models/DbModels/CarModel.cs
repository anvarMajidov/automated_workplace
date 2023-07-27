namespace Models.DbModels;

public class CarModel : BaseEntity
{
    public string Name { get; set; }
    
    public Guid BrandId { get; set; }
    public CarBrand Brand { get; set; }

    public List<Car> Cars { get; set; }
}
