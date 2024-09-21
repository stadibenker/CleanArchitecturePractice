using ClearArchitecture.Application.Features.LeaveRequest.Shared;

namespace ClearArchitecture.Application.Features.LeaveRequest.Commands.UpdateRequest
{
	public class UpdateLeaveRequestDto : BaseLeaveRequest
	{
		public int Id { get; set; }
		public string RequestComments { get; set; } = string.Empty;
		public bool Cancelled { get; set; }
	}
}
