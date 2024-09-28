using AutoMapper;
using ClearArchitecture.Application.Contracts.Persistence;
using MediatR;

namespace ClearArchitecture.Application.Features.LeaveType.Commands.UpdateLeaveType
{
	public class UpdateLeaveTypeCommandHandler : IRequestHandler<UpdateLeaveTypeCommand, Unit>
	{
		private readonly IMapper _mapper;
		private readonly ILeaveTypeRepository _repository;

		public UpdateLeaveTypeCommandHandler(IMapper mapper ,ILeaveTypeRepository repository)
		{
			_mapper = mapper;
			_repository = repository;
		}

		public async Task<Unit> Handle(UpdateLeaveTypeCommand request, CancellationToken cancellationToken)
		{
			var validator = new UpdateLeaveTypeCommandValidator(_repository);
			var validationResult = await validator.ValidateAsync(request);

			var leaveTypeToUpdate = _mapper.Map<CleanArchitecture.Domain.LeaveType>(request);

			await _repository.UpdateAsync(leaveTypeToUpdate);

			return Unit.Value;
		}
	}
}
