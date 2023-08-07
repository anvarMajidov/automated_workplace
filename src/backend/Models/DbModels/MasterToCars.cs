namespace Models.DbModels;

public class MasterToCars : BaseEntity
{
    public Guid MasterId { get; set; }
    public Master Master { get; set; }

    public Guid CarId { get; set; }
    public Car Car { get; set; }
}
