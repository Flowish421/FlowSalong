namespace FlowSalong.Application.Features.Customers.DTOs;

public record CustomerUpdateDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;
}
