﻿using AutoMapper;
using ClearArchitecture.Application.Contracts.Persistence;
using MediatR;

namespace ClearArchitecture.Application.Features.LeaveRequest.Queries.GetLeaveRequestList
{
	public class GetLeaveRequestListQueryHandler : IRequestHandler<GetLeaveRequestListQuery, List<LeaveRequestDto>>
	{
		private readonly ILeaveRequestRepository _leaveRequestRepository;
		private readonly IMapper _mapper;

		public GetLeaveRequestListQueryHandler(ILeaveRequestRepository leaveRequestRepository, IMapper mapper)
		{
			_leaveRequestRepository = leaveRequestRepository;
			_mapper = mapper;
		}

		public async Task<List<LeaveRequestDto>> Handle(GetLeaveRequestListQuery request, CancellationToken cancellationToken)
		{
			var leaveRequests = await _leaveRequestRepository.GetLeaveRequestsWithDetails();

			var requests = _mapper.Map<List<LeaveRequestDto>>(leaveRequests);

			return requests;
		}
	}
}
