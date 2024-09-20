using AutoMapper;
using ClearArchitecture.Application.Contracts.Persistence;
using MediatR;

namespace ClearArchitecture.Application.Features.LeaveAllocation.Queries.GetLeaveAllocations
{
	public class GetLeaveAllocationListHandler : IRequestHandler<GetLeaveAllocationsQuery, List<LeaveAllocationDto>>
	{
		private readonly ILeaveAllocationRepository _leaveAllocationRepository;
		private readonly IMapper _mapper;

		public GetLeaveAllocationListHandler(ILeaveAllocationRepository leaveAllocationRepository, IMapper mapper)
		{
			_leaveAllocationRepository = leaveAllocationRepository;
			_mapper = mapper;
		}

		public async Task<List<LeaveAllocationDto>> Handle(GetLeaveAllocationsQuery request, CancellationToken cancellationToken)
		{
			var leaveAllocations = await _leaveAllocationRepository.GetLeaveAllocationsWithDetails();
			
			var allocations = _mapper.Map<List<LeaveAllocationDto>>(leaveAllocations);

			return allocations;
		}
	}
}
