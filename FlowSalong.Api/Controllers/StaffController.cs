using MediatR;
using Microsoft.AspNetCore.Mvc;
using FlowSalong.Application.Features.Staffs.Commands;
using FlowSalong.Application.Features.Staffs.Queries;

namespace FlowSalong.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StaffController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StaffController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET api/staff
        [HttpGet]
        public async Task<IActionResult> GetAll() =>
            Ok(await _mediator.Send(new GetAllStaffQuery()));

        // GET api/staff/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id) =>
            Ok(await _mediator.Send(new GetStaffByIdQuery { Id = id }));

        // POST api/staff
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateStaffCommand command) =>
            Ok(await _mediator.Send(command));

        // PUT api/staff/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateStaffCommand command)
        {
            // Om UpdateStaffCommand är record: använd with
            var fixedCommand = command with { Id = id };
            // Om det är class: command.Id = id;

            var result = await _mediator.Send(fixedCommand);
            if (!result.Success) return BadRequest(result);
            return Ok(result);
        }

        // DELETE api/staff/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            // Dina staff-kommandon var "record" med ctor(Guid Id) i dina bilder:
            var result = await _mediator.Send(new DeleteStaffCommand(id));
            // Om din typ istället är class: new DeleteStaffCommand { Id = id };

            if (!result.Success) return NotFound(result);
            return Ok(result);
        }
    }
}
