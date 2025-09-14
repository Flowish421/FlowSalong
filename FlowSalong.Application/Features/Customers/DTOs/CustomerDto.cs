using System;

namespace FlowSalong.Application.Features.Customers.DTOs
{
    public record CustomerDto(Guid Id, string Name, string Email);
}
