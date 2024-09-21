using MediatR;

namespace ClearArchitecture.Application.Features.LeaveRequest.Queries.GetLeaveRequestList
{
	public class GetLeaveRequestListQuery : IRequest<List<LeaveRequestDto>>
	{
	}
}
