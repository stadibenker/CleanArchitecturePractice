using AutoMapper;
using ClearArchitecture.Application.Contracts.Persistence;
using MediatR;

namespace ClearArchitecture.Application.Features.LeaveType.Queries.GetAllLeaveTypes
{
	public class GetLeaveTypesHandler : IRequestHandler<GetLeaveTypesQuery, List<LeaveTypeDto>>
	{
		private readonly IMapper _mapper;
		private readonly ILeaveTypeRepository _repository;

		public GetLeaveTypesHandler(IMapper mapper, ILeaveTypeRepository repository)
		{
			_mapper = mapper;
			_repository = repository;
		}

		public async Task<List<LeaveTypeDto>> Handle(GetLeaveTypesQuery request, CancellationToken cancellationToken)
		{
			var leaveTypes = await _repository.GetAsync();

			var data = _mapper.Map<List<LeaveTypeDto>>(leaveTypes);

			return data;
		}
	}
}
