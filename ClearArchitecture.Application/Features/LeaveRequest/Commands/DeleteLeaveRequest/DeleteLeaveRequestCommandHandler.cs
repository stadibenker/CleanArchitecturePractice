﻿using ClearArchitecture.Application.Contracts.Persistence;
using ClearArchitecture.Application.Exceptions;
using MediatR;

namespace ClearArchitecture.Application.Features.LeaveRequest.Commands.DeleteLeaveRequest
{
	public class DeleteLeaveRequestCommandHandler : IRequestHandler<DeleteLeaveRequestCommand, Unit>
	{
		private readonly ILeaveRequestRepository _leaveRequestRepository;

		public DeleteLeaveRequestCommandHandler(ILeaveRequestRepository leaveRequestRepository)
		{
			_leaveRequestRepository = leaveRequestRepository;
		}

		public async Task<Unit> Handle(DeleteLeaveRequestCommand request, CancellationToken cancellationToken)
		{
			var leaveRequest = await _leaveRequestRepository.GetByIdAsync(request.Id);

			if (leaveRequest == null)
				throw new NotFoundException(nameof(LeaveRequest), request.Id);

			await _leaveRequestRepository.DeleteAsync(leaveRequest);
			return Unit.Value;
		}
	}
}
