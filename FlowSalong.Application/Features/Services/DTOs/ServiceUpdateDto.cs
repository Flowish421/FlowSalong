namespace FlowSalong.Application.Features.Services.DTOs
{
    public record ServiceUpdateDto(
        System.Guid Id,
        string Name,
        decimal Price
    );
}
