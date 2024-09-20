using MediatR;

namespace ClearArchitecture.Application.Features.LeaveAllocation.Commands.DeleteLeaveAllocation
{
	public class DeleteLeaveAllocationCommand : IRequest<Unit>
	{
		public int Id { get; set; }
	}
}
