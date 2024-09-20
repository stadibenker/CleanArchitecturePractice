using ClearArchitecture.Application.Features.LeaveType.Commands.CreateLeaveType;
using ClearArchitecture.Application.Features.LeaveType.Commands.DeleteLeaveType;
using ClearArchitecture.Application.Features.LeaveType.Commands.UpdateLeaveType;
using ClearArchitecture.Application.Features.LeaveType.Queries.GetAllLeaveTypes;
using ClearArchitecture.Application.Features.LeaveType.Queries.GetLeaveTypeDetails;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ClearArchitecture.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class LeaveTypesController : ControllerBase
	{
		private readonly IMediator _mediator;

		public LeaveTypesController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpGet]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<ActionResult<List<LeaveTypeDto>>> Get()
		{
			var leaveTypes = await _mediator.Send(new GetLeaveTypesQuery());
			return Ok(leaveTypes);
		}

		[HttpGet("{id}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<ActionResult<LeaveTypeDetailsDto>> Get(int id)
		{
			var leaveType = await _mediator.Send(new GetLeaveTypeDetailsQuery(id));
			return Ok(leaveType);
		}

		[HttpPost]
		[ProducesResponseType(StatusCodes.Status201Created)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public async Task<ActionResult> Post(CreateLeaveTypeDto leaveType)
		{
			var response = await _mediator.Send(new CreateLeaveTypeCommand
			{
				Name = leaveType.Name,
				DefaultDays = leaveType.DefaultDays,
			});
			return CreatedAtAction(nameof(Get), new { id = response });
		}

		[HttpPut("{id}")]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult> Put(int id, UpdateLeaveTypeDto leaveType)
		{
			await _mediator.Send(new UpdateLeaveTypeCommand
			{
				Id = id,
				Name = leaveType.Name,
				DefaultDays = leaveType.DefaultDays
			});
			return NoContent();
		}

		[HttpDelete("{id}")]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult> Delete(int id)
		{
			var command = new DeleteLeaveTypeCommand { Id = id };
			await _mediator.Send(command);
			return NoContent();
		}
	}
}
