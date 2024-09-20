using AutoMapper;
using ClearArchitecture.Application.Contracts.Persistence;
using ClearArchitecture.Application.Exceptions;
using MediatR;

namespace ClearArchitecture.Application.Features.LeaveAllocation.Queries.GetLeaveAllocationDetails
{
	public class GetLeaveAllocationDetailsRequestHandler : IRequestHandler<GetLeaveAllocationDetailsQuery, LeaveAllocationDetailsDto>
	{
		private readonly ILeaveAllocationRepository _leaveAllocationRepository;
		private readonly IMapper _mapper;

		public GetLeaveAllocationDetailsRequestHandler(ILeaveAllocationRepository leaveAllocationRepository, IMapper mapper)
		{
			_leaveAllocationRepository = leaveAllocationRepository;
			_mapper = mapper;
		}

		public async Task<LeaveAllocationDetailsDto> Handle(GetLeaveAllocationDetailsQuery request, CancellationToken cancellationToken)
		{
			var leaveAllocation = await _leaveAllocationRepository.GetLeaveAllocationWithDetails(request.Id);
			if (leaveAllocation == null)
				throw new NotFoundException(nameof(LeaveAllocation), request.Id);

			return _mapper.Map<LeaveAllocationDetailsDto>(leaveAllocation);
		}
	}
}
