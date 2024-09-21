using ClearArchitecture.Application.Features.LeaveRequest.Shared;

namespace ClearArchitecture.Application.Features.LeaveRequest.Commands.CreateLeaveRequest
{
	public class CreateLeaveRequestDto : BaseLeaveRequest
	{
		public string RequestComments { get; set; } = string.Empty;
	}
}
