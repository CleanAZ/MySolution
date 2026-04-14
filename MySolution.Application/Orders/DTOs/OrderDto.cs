namespace MySolution.Application.DTOs;
public record OrderDto(Guid Id,decimal Total,string Description,DateTime orderDate);