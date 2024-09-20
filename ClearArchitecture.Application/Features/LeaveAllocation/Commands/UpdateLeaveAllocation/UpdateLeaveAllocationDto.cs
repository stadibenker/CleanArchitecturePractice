namespace ClearArchitecture.Application.Features.LeaveAllocation.Commands.UpdateLeaveAllocation
{
	public class UpdateLeaveAllocationDto
	{
		public int NumberOfDays { get; set; }
		public int LeaveTypeId { get; set; }
		public int Period { get; set; }
	}
}
