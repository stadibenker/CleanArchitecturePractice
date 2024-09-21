using AutoMapper;
using ClearArchitecture.Application.Contracts.Persistence;
using ClearArchitecture.Application.Exceptions;
using MediatR;

namespace ClearArchitecture.Application.Features.LeaveRequest.Queries.GetLeaveRequestDetails
{
	public class GetLeaveRequestDetailsQueryHandler : IRequestHandler<GetLeaveRequestDetailsQuery, LeaveRequestDetailsDto>
	{
		private readonly ILeaveRequestRepository _leaveRequestRepository;
		private readonly IMapper _mapper;

		public GetLeaveRequestDetailsQueryHandler(ILeaveRequestRepository leaveRequestRepository, IMapper mapper)
		{
			_leaveRequestRepository = leaveRequestRepository;
			_mapper = mapper;
		}

		public async Task<LeaveRequestDetailsDto> Handle(GetLeaveRequestDetailsQuery request, CancellationToken cancellationToken)
		{
			var leaveRequest = _mapper.Map<LeaveRequestDetailsDto>(await _leaveRequestRepository.GetLeaveRequestWithDetails(request.Id));

			if (leaveRequest == null)
				throw new NotFoundException(nameof(LeaveRequest), request.Id);

			return leaveRequest;
		}
	}
}
