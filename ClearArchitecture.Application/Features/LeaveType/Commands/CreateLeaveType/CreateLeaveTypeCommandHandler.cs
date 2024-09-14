using AutoMapper;
using ClearArchitecture.Application.Contracts.Persistence;
using MediatR;

namespace ClearArchitecture.Application.Features.LeaveType.Commands.CreateLeaveType
{
	public class UpdateLeaveTypeCommandHandler : IRequestHandler<UpdateLeaveTypeCommand, int>
	{
		private readonly IMapper _mapper;
		private readonly ILeaveTypeRepository _repository;

		public UpdateLeaveTypeCommandHandler(IMapper mapper ,ILeaveTypeRepository repository)
		{
			_mapper = mapper;
			_repository = repository;
		}

		public async Task<int> Handle(UpdateLeaveTypeCommand request, CancellationToken cancellationToken)
		{
			var leaveTypeToCreate = _mapper.Map<CleanArchitecture.Domain.LeaveType>(request);

			await _repository.CreateAsync(leaveTypeToCreate);

			return leaveTypeToCreate.Id;
		}
	}
}
