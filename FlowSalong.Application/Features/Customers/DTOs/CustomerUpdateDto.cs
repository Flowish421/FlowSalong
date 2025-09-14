namespace FlowSalong.Application.Features.Customers.DTOs;

public record CustomerUpdateDto(
    int Id,
    string Name,
    string Email
);
