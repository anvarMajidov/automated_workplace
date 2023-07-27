using System.ComponentModel.DataAnnotations;

namespace Models.DbModels;

public class Client : BaseEntity
{
    public string Name { get; set; }
    
    public string Surname { get; set; }
    
    public string Patronymic { get; set; }
    
    [RegularExpression(@"^[\+]?[(]?\d{3}[)]?[-\s\.]?\d{3}[-\s\.]?\d{4,6}$")]
    public string Phone { get; set; }
    
    public List<Car> Cars { get; set; }
}
