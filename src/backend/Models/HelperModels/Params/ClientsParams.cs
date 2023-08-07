namespace Models.HelperModels.Params;

public class ClientsParams : PaginationParams
{
    /// <summary>
    /// Сортировка по заданному свойству
    /// </summary>
    /// <example> Name, Surname, CreatedDate </example>
    public string? OrderBy { get; set; }
    /// <summary>
    /// Получает пользователей с заданным брэндом/моделем машины
    /// </summary>
    /// <example> "Cars."</example>
    public Filter? CarFilter { get; set; }
}
