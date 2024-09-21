using ClearArchitecture.Application.Features.LeaveRequest.Shared;
using MediatR;

namespace ClearArchitecture.Application.Features.LeaveRequest.Commands.CreateLeaveRequest
{
	public class CreateLeaveRequestCommand : BaseLeaveRequest, IRequest<Unit>
	{
		public string RequestComments { get; set; } = string.Empty;
	}
}
