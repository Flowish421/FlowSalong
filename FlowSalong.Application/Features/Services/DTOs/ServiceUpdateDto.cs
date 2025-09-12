namespace FlowSalong.Application.Features.Services.DTOs;

public record ServiceUpdateDto(
    int Id,
    string Name,
    decimal Price
);
