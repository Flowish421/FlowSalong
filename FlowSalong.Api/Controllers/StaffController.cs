using FlowSalong.Application.Features.Staffs;
using FlowSalong.Application.Features.Staffs.Commands;
using FlowSalong.Application.Features.Staffs.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FlowSalong.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StaffController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll() =>
        Ok(await mediator.Send(new GetAllStaffQuery()));

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id) =>
        Ok(await mediator.Send(new GetStaffByIdQuery(id)));

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateStaffCommand command) =>
        Ok(await mediator.Send(command));

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateStaffCommand command) =>
        Ok(await mediator.Send(command with { Id = id }));

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id) =>
        Ok(await mediator.Send(new DeleteStaffCommand(id)));
}
