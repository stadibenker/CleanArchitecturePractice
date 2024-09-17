using AutoMapper;
using ClearArchitecture.Application.Contracts.Logging;
using ClearArchitecture.Application.Contracts.Persistence;
using MediatR;

namespace ClearArchitecture.Application.Features.LeaveType.Queries.GetAllLeaveTypes
{
	public class GetLeaveTypesHandler : IRequestHandler<GetLeaveTypesQuery, List<LeaveTypeDto>>
	{
		private readonly IMapper _mapper;
		private readonly ILeaveTypeRepository _repository;
		private readonly IAppLogger<GetLeaveTypesHandler> _logger;

		public GetLeaveTypesHandler(IMapper mapper, ILeaveTypeRepository repository, IAppLogger<GetLeaveTypesHandler> logger)
		{
			_mapper = mapper;
			_repository = repository;
			_logger = logger;
		}

		public async Task<List<LeaveTypeDto>> Handle(GetLeaveTypesQuery request, CancellationToken cancellationToken)
		{
			var leaveTypes = await _repository.GetAsync();

			var data = _mapper.Map<List<LeaveTypeDto>>(leaveTypes);

			_logger.LogInformation("Leave types were retrieved successfully.");

			return data;
		}
	}
}
