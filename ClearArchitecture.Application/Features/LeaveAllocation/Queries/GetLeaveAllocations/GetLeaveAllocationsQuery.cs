using MediatR;

namespace ClearArchitecture.Application.Features.LeaveAllocation.Queries.GetLeaveAllocations
{
	public class GetLeaveAllocationsQuery : IRequest<List<LeaveAllocationDto>>
	{
	}
}
