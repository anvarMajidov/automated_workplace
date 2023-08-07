﻿namespace Models.HelperModels.Params;

public class PaginationParams
{
    private const int MaxPageSize = 25;

    public int PageNumber { get; set; } = 1;
    public int PageSize
    {
        get => _pageSize;
        set => _pageSize = value > MaxPageSize ? MaxPageSize : value;
    }
    
    private int _pageSize = 10;
}
