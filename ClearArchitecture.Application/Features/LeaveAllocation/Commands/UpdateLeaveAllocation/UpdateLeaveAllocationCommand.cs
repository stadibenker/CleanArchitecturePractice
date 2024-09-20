using MediatR;

namespace ClearArchitecture.Application.Features.LeaveAllocation.Commands.UpdateLeaveAllocation
{
	public class UpdateLeaveAllocationCommand : IRequest<Unit>
	{
		public int Id { get; set; }
		public int NubmerOfDays { get; set; }
		public int LeaveTypeId { get; set; }
		public int Period { get; set; }
	}
}
