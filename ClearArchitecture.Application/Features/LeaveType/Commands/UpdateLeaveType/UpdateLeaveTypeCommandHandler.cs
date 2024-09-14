using AutoMapper;
using ClearArchitecture.Application.Contracts.Persistence;
using MediatR;

namespace ClearArchitecture.Application.Features.LeaveType.Commands.UpdateLeaveType
{
	public class DeleteLeaveTypeCommandHandler : IRequestHandler<DeleteLeaveTypeCommand, Unit>
	{
		private readonly IMapper _mapper;
		private readonly ILeaveTypeRepository _repository;

		public DeleteLeaveTypeCommandHandler(IMapper mapper ,ILeaveTypeRepository repository)
		{
			_mapper = mapper;
			_repository = repository;
		}

		public async Task<Unit> Handle(DeleteLeaveTypeCommand request, CancellationToken cancellationToken)
		{
			var leaveTypeToUpdate = _mapper.Map<CleanArchitecture.Domain.LeaveType>(request);

			await _repository.UpdateAsync(leaveTypeToUpdate);

			return Unit.Value;
		}
	}
}
