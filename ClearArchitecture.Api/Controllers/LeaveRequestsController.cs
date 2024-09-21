using ClearArchitecture.Application.Features.LeaveRequest.Commands.CreateLeaveRequest;
using ClearArchitecture.Application.Features.LeaveRequest.Commands.DeleteLeaveRequest;
using ClearArchitecture.Application.Features.LeaveRequest.Commands.UpdateRequest;
using ClearArchitecture.Application.Features.LeaveRequest.Queries.GetLeaveRequestDetails;
using ClearArchitecture.Application.Features.LeaveRequest.Queries.GetLeaveRequestList;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ClearArchitecture.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveRequestsController : ControllerBase
    {
		private readonly IMediator _mediator;

		public LeaveRequestsController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpGet]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<ActionResult<List<LeaveRequestDto>>> Get()
        {
            var result = await _mediator.Send(new GetLeaveRequestListQuery());
            
            return Ok(result);
        }

        [HttpGet("{id}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<ActionResult<LeaveRequestDetailsDto>> Get(int id)
        {
			var result = await _mediator.Send(new GetLeaveRequestDetailsQuery() { Id = id });

			return Ok(result);
		}

        [HttpPost]
		[ProducesResponseType(StatusCodes.Status201Created)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public async Task<ActionResult> Post(CreateLeaveRequestDto request)
        {
			var response = await _mediator.Send(new CreateLeaveRequestCommand
			{
				EndDate = request.EndDate,
				LeaveTypeId = request.LeaveTypeId,
				RequestComments = request.RequestComments,
				StartDate = request.StartDate,
			});
			return CreatedAtAction(nameof(Get), new { id = response });
		}

		[HttpPut("{id}")]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult> Put(int id, UpdateLeaveRequestDto request)
        {
			await _mediator.Send(new UpdateLeaveRequestCommand
			{
				Id = id,
				LeaveTypeId = request.LeaveTypeId,
				RequestComments = request.RequestComments,
				StartDate = request.StartDate,
				EndDate = request.EndDate,
				Cancelled = request.Cancelled,
			});
			return NoContent();
		}

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
			var command = new DeleteLeaveRequestCommand { Id = id };

			await _mediator.Send(command);

			return NoContent();
		}
    }
}
