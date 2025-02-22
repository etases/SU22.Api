﻿namespace CP.Api.DTOs.Response;

public record PaginationParameter
{
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
}