using MediatR;

namespace ClearArchitecture.Application.Features.LeaveType.Commands.UpdateLeaveType
{
	public class DeleteLeaveTypeCommand : IRequest<Unit>
	{
		public string Name { get; set; } = string.Empty;
		public int DefaultDays { get; set; }
	}
}
