using MediatR;

namespace ClearArchitecture.Application.Features.LeaveAllocation.Queries.GetLeaveAllocationDetails
{
	public class GetLeaveAllocationDetailsQuery : IRequest<LeaveAllocationDetailsDto>
	{
		public int Id { get; set; }
	}
}
