namespace ClearArchitecture.Application.Features.LeaveType.Commands.CreateLeaveType
{
	public class CreateLeaveTypeDto
	{
		public string Name { get; set; } = string.Empty;
		public int DefaultDays { get; set; }
	}
}
