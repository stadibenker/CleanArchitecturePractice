using ClearArchitecture.Application.Contracts.Persistence;
using ClearArchitecture.Application.Exceptions;
using MediatR;

namespace ClearArchitecture.Application.Features.LeaveType.Commands.DeleteLeaveType
{
	public class DeleteLeaveTypeCommandHandler : IRequestHandler<DeleteLeaveTypeCommand, Unit>
	{
		private readonly ILeaveTypeRepository _repository;

		public DeleteLeaveTypeCommandHandler(ILeaveTypeRepository repository)
		{
			_repository = repository;
		}

		public async Task<Unit> Handle(DeleteLeaveTypeCommand request, CancellationToken cancellationToken)
		{
			var leaveTypeToDelete = await _repository.GetByIdAsync(request.Id);

			if (leaveTypeToDelete == null) {
				throw new NotFoundException(nameof(CleanArchitecture.Domain.LeaveType), request.Id);
			}

			await _repository.DeleteAsync(leaveTypeToDelete);

			return Unit.Value;
		}
	}
}
