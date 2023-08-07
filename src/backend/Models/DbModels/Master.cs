namespace Models.DbModels;

public class Master : BaseEntity
{
    public string Surname { get; set; }
    public string Name { get; set; }
    public string Patronymic { get; set; }

    public List<Car> Cars { get; set; } = new();
}
