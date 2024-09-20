using ClearArchitecture.Application.Features.LeaveAllocation.Commands.CreateLeaveAllocation;
using ClearArchitecture.Application.Features.LeaveAllocation.Commands.DeleteLeaveAllocation;
using ClearArchitecture.Application.Features.LeaveAllocation.Commands.UpdateLeaveAllocation;
using ClearArchitecture.Application.Features.LeaveAllocation.Queries.GetLeaveAllocationDetails;
using ClearArchitecture.Application.Features.LeaveAllocation.Queries.GetLeaveAllocations;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ClearArchitecture.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class LeaveAllocationsController : ControllerBase
	{
		private readonly IMediator _mediator;

		public LeaveAllocationsController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpGet]
		public async Task<ActionResult<List<LeaveAllocationDto>>> Get()
		{
			var result = await _mediator.Send(new GetLeaveAllocationsQuery());

			return Ok(result);
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<LeaveAllocationDetailsDto>> Get(int id)
		{
			var result = await _mediator.Send(new GetLeaveAllocationDetailsQuery { Id = id });

			return Ok(result);
		}

		[HttpPost]
		[ProducesResponseType(StatusCodes.Status201Created)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public async Task<ActionResult> Post(CreateLeaveAllocationDto request)
		{
			var response = await _mediator.Send(new CreateLeaveAllocationCommand {
				LeaveTypeId = request.LeaveTypeId,
			});
			return CreatedAtAction(nameof(Get), new { id = response });
		}

		[HttpPut("{id}")]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult> Put(int id, UpdateLeaveAllocationDto request)
		{
			await _mediator.Send(new UpdateLeaveAllocationCommand { 
				Id = id,
				LeaveTypeId= request.LeaveTypeId,
				NubmerOfDays = request.NumberOfDays,
				Period = request.Period
			});
			return NoContent();
		}

		[HttpDelete("{id}")]
		public async Task<ActionResult> Delete(int id)
		{
			await _mediator.Send(new DeleteLeaveAllocationCommand { Id = id });

			return Ok();
		}
	}
}
