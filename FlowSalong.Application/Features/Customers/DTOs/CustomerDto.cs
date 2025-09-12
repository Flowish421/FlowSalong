namespace FlowSalong.Application.Features.Customers.DTOs;

public record CustomerDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;
}
