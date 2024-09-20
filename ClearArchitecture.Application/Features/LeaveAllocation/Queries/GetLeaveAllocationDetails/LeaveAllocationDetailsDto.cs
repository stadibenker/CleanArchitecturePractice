using ClearArchitecture.Application.Features.LeaveType.Queries.GetAllLeaveTypes;

namespace ClearArchitecture.Application.Features.LeaveAllocation.Queries.GetLeaveAllocationDetails
{
	public class LeaveAllocationDetailsDto
	{
		public int Id { get; set; }
		public int NubmerOfDays { get; set; }
		public LeaveTypeDto LeaveType { get; set; }
		public int LeaveTypeId { get; set; }
		public int Period { get; set; }
	}
}
