using ClearArchitecture.Application.Features.LeaveRequest.Shared;
using MediatR;

namespace ClearArchitecture.Application.Features.LeaveRequest.Commands.UpdateRequest
{
	public class UpdateLeaveRequestCommand : BaseLeaveRequest, IRequest<Unit>
	{
		public int Id { get; set; }
		public string RequestComments { get; set; } = string.Empty;
		public bool Cancelled { get; set; }
	}
}
