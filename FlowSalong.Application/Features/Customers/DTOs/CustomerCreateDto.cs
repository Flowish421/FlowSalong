namespace FlowSalong.Application.Features.Customers.DTOs;

public record CustomerCreateDto
{
    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;
}
