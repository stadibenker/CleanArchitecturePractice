using ClearArchitecture.Application.Contracts.Persistence;
using ClearArchitecture.Application.Exceptions;
using MediatR;

namespace ClearArchitecture.Application.Features.LeaveAllocation.Commands.DeleteLeaveAllocation
{
	public class DeleteLeaveAllocationCommandHandler : IRequestHandler<DeleteLeaveAllocationCommand, Unit>
	{
		private readonly ILeaveAllocationRepository _repository;

		public DeleteLeaveAllocationCommandHandler(ILeaveAllocationRepository repository)
		{
			_repository = repository;
		}

		public async Task<Unit> Handle(DeleteLeaveAllocationCommand request, CancellationToken cancellationToken)
		{
			var leaveAllocationToDelete = await _repository.GetByIdAsync(request.Id);

			if (leaveAllocationToDelete == null)
			{
				throw new NotFoundException(nameof(CleanArchitecture.Domain.LeaveAllocation), request.Id);
			}

			await _repository.DeleteAsync(leaveAllocationToDelete);

			return Unit.Value;
		}
	}
}
