using AutoMapper;
using ClearArchitecture.Application.Contracts.Email;
using ClearArchitecture.Application.Contracts.Logging;
using ClearArchitecture.Application.Contracts.Persistence;
using ClearArchitecture.Application.Exceptions;
using ClearArchitecture.Application.Models.Email;
using MediatR;

namespace ClearArchitecture.Application.Features.LeaveRequest.Commands.UpdateRequest
{
	public class UpdateLeaveRequestCommandHandler : IRequestHandler<UpdateLeaveRequestCommand, Unit>
	{
		private readonly IMapper _mapper;
		private readonly IEmailSender _emailSender;
		private readonly IAppLogger<UpdateLeaveRequestCommandHandler> _appLogger;
		private readonly ILeaveRequestRepository _leaveRequestRepository;
		private readonly ILeaveTypeRepository _leaveTypeRepository;

		public UpdateLeaveRequestCommandHandler(
			 ILeaveRequestRepository leaveRequestRepository, ILeaveTypeRepository leaveTypeRepository, IMapper mapper, IEmailSender emailSender, IAppLogger<UpdateLeaveRequestCommandHandler> appLogger)
		{
			_leaveRequestRepository = leaveRequestRepository;
			_leaveTypeRepository = leaveTypeRepository;
			_mapper = mapper;
			_emailSender = emailSender;
			_appLogger = appLogger;
		}

		public async Task<Unit> Handle(UpdateLeaveRequestCommand request, CancellationToken cancellationToken)
		{
			var leaveRequest = await _leaveRequestRepository.GetByIdAsync(request.Id);

			if (leaveRequest is null)
				throw new NotFoundException(nameof(LeaveRequest), request.Id);

			_mapper.Map(request, leaveRequest);

			await _leaveRequestRepository.UpdateAsync(leaveRequest);

			try
			{
				var email = new EmailMessage
				{
					To = string.Empty,
					Body = $"Your leave request for {request.StartDate:D} to {request.EndDate:D} " +
							$"has been updated successfully.",
					Subject = "Leave Request Updated"
				};

				await _emailSender.SendEmail(email);
			}
			catch (Exception ex)
			{
				_appLogger.LogWarning(ex.Message);
			}

			return Unit.Value;
		}
	}
}
