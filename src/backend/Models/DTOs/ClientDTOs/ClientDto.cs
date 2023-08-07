using Models.DbModels;

namespace Models.DTOs.ClientDTOs;

public record ClientDto
{
    public string Name { get; set; }
    
    public string Surname { get; set; }
    
    public string Patronymic { get; set; }
    
    public string Phone { get; set; }
    
    public List<Car> Cars { get; set; }
}
