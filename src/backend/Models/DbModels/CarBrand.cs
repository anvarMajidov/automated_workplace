namespace Models.DbModels;

public class CarBrand : BaseEntity
{
    public string Name { get; set; }

    public List<Car> Cars { get; set; }
    public List<CarModel> CarModels { get; set; }
}
