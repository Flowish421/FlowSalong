using MediatR;
using Microsoft.AspNetCore.Mvc;
using FlowSalong.Application.Features.Customers.Commands;
using FlowSalong.Application.Features.Customers.Queries;

namespace FlowSalong.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CustomerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // POST api/customer
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCustomerCommand command)
        {
            var result = await _mediator.Send(command);
            if (!result.Success) return BadRequest(result);
            return Ok(result);
        }

        // GET api/customer/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _mediator.Send(new GetCustomerByIdQuery { Id = id });
            if (!result.Success) return NotFound(result);
            return Ok(result);
        }

        // GET api/customer
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllCustomersQuery());
            return Ok(result);
        }

        // PUT api/customer/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateCustomerCommand command)
        {
            // om ditt UpdateCustomerCommand är ett "class" med set; set; properties
            // och Id är Guid:
            var fixedCommand = command with { Id = id }; // funkar om UpdateCustomerCommand är record
            // Om UpdateCustomerCommand är "class" (inte record), använd:
            // command.Id = id;

            var result = await _mediator.Send(fixedCommand);
            if (!result.Success) return BadRequest(result);
            return Ok(result);
        }

        // DELETE api/customer/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            // Om ditt DeleteCustomerCommand är ett class med Id-property:
            var result = await _mediator.Send(new DeleteCustomerCommand(id));
            // Om det istället är class utan ctor: new DeleteCustomerCommand { Id = id }

            if (!result.Success) return NotFound(result);
            return Ok(result);
        }
    }
}
