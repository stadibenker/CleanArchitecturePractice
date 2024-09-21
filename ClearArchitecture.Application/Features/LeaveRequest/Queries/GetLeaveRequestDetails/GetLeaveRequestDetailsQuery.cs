using MediatR;

namespace ClearArchitecture.Application.Features.LeaveRequest.Queries.GetLeaveRequestDetails
{
	public class GetLeaveRequestDetailsQuery : IRequest<LeaveRequestDetailsDto>
	{
		public int Id { get; set; }
	}
}
