using MediatR;
using Microsoft.AspNetCore.Mvc;
using FlowSalong.Application.Common.Models;
using FlowSalong.Application.Features.Services.Commands;
using FlowSalong.Application.Features.Services.DTOs;
using FlowSalong.Application.Features.Services.Queries;

namespace FlowSalong.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ServiceController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ServiceController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET api/service
        [HttpGet]
        public async Task<ActionResult<OperationResult<List<ServiceDto>>>> GetAll()
        {
            var result = await _mediator.Send(new GetAllServicesQuery());
            return Ok(result);
        }

        // GET api/service/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<OperationResult<ServiceDto>>> GetById(Guid id)
        {
            var result = await _mediator.Send(new GetServiceByIdQuery { Id = id });
            if (!result.Success) return NotFound(result);
            return Ok(result);
        }

        // POST api/service
        [HttpPost]
        public async Task<ActionResult<OperationResult<ServiceDto>>> Create([FromBody] ServiceCreateDto dto)
        {
            var command = new CreateServiceCommand
            {
                Name = dto.Name,
                Price = dto.Price
            };

            var result = await _mediator.Send(command);
            if (!result.Success) return BadRequest(result);
            return Ok(result);
        }

        // PUT api/service/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult<OperationResult<ServiceDto>>> Update(Guid id, [FromBody] ServiceUpdateDto dto)
        {
            var command = new UpdateServiceCommand
            {
                Id = id,
                Name = dto.Name,
                Price = dto.Price
            };

            var result = await _mediator.Send(command);
            if (!result.Success) return NotFound(result);
            return Ok(result);
        }

        // DELETE api/service/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult<OperationResult<bool>>> Delete(Guid id)
        {
            // DeleteServiceCommand är en "class" med Id-property i din kod
            var result = await _mediator.Send(new DeleteServiceCommand { Id = id });
            if (!result.Success) return NotFound(result);
            return Ok(result);
        }
    }
}
