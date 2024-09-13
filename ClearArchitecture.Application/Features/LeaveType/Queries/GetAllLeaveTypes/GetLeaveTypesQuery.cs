using MediatR;

namespace ClearArchitecture.Application.Features.LeaveType.Queries.GetAllLeaveTypes
{
	public record GetLeaveTypesQuery : IRequest<List<LeaveTypeDto>>
	{
	}
}
