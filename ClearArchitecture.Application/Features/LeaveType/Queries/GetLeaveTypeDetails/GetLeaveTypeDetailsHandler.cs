using AutoMapper;
using ClearArchitecture.Application.Contracts.Persistence;
using ClearArchitecture.Application.Exceptions;
using MediatR;

namespace ClearArchitecture.Application.Features.LeaveType.Queries.GetLeaveTypeDetails
{
	public class GetLeaveTypeDetailsHandler : IRequestHandler<GetLeaveTypeDetailsQuery, LeaveTypeDetailsDto>
	{
		private readonly IMapper _mapper;
		private readonly ILeaveTypeRepository _repository;

		public GetLeaveTypeDetailsHandler(IMapper mapper, ILeaveTypeRepository repository)
		{
			_mapper = mapper;
			_repository = repository;
		}

		public async Task<LeaveTypeDetailsDto> Handle(GetLeaveTypeDetailsQuery request, CancellationToken cancellationToken)
		{
			var leaveType = await _repository.GetByIdAsync(request.Id);

			if (leaveType == null)
			{
				throw new NotFoundException(nameof(CleanArchitecture.Domain.LeaveType), request.Id);
			}

			var data = _mapper.Map<LeaveTypeDetailsDto>(leaveType);

			return data;
		}
	}
}
