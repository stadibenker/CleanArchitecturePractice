namespace ClearArchitecture.Application.Features.LeaveType.Commands.UpdateLeaveType
{
	public class UpdateLeaveTypeDto
	{
		public string Name { get; set; } = string.Empty;
		public int DefaultDays { get; set; }
	}
}
