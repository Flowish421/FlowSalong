using Microsoft.AspNetCore.Mvc;
using MediatR;
using FlowSalong.Application.Features.Services.Commands;
using FlowSalong.Application.Features.Services.DTOs;
using FlowSalong.Application.Features.Services.Queries;
using FlowSalong.Application.Common.Models;
using System.Threading.Tasks;

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

        [HttpGet]
        public async Task<ActionResult<OperationResult<ServiceDto[]>>> GetAll()
        {
            var result = await _mediator.Send(new GetAllServicesQuery());
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OperationResult<ServiceDto>>> GetById(int id)
        {
            var result = await _mediator.Send(new GetServiceByIdQuery(id));
            if (!result.Success) return NotFound(result);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<OperationResult<ServiceDto>>> Create([FromBody] ServiceCreateDto dto)
        {
            var command = new CreateServiceCommand(dto.Name, dto.Price);
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<OperationResult<ServiceDto>>> Update(int id, [FromBody] ServiceUpdateDto dto)
        {
            var command = new UpdateServiceCommand(id, dto.Name, dto.Price);
            var result = await _mediator.Send(command);
            if (!result.Success) return NotFound(result);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<OperationResult<bool>>> Delete(int id)
        {
            var command = new DeleteServiceCommand(id);
            var result = await _mediator.Send(command);
            if (!result.Success) return NotFound(result);
            return Ok(result);
        }
    }
}
