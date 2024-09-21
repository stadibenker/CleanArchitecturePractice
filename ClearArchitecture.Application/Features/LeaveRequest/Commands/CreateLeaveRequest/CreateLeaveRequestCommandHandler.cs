using AutoMapper;
using ClearArchitecture.Application.Contracts.Email;
using ClearArchitecture.Application.Contracts.Persistence;
using ClearArchitecture.Application.Models.Email;
using MediatR;

namespace ClearArchitecture.Application.Features.LeaveRequest.Commands.CreateLeaveRequest
{
	public class CreateLeaveRequestCommandHandler : IRequestHandler<CreateLeaveRequestCommand, Unit>
	{
		private readonly IEmailSender _emailSender;
		private readonly IMapper _mapper;
		private readonly ILeaveRequestRepository _leaveRequestRepository;

		public CreateLeaveRequestCommandHandler(IEmailSender emailSender, IMapper mapper, ILeaveRequestRepository leaveRequestRepository)
		{
			_emailSender = emailSender;
			_mapper = mapper;
			_leaveRequestRepository = leaveRequestRepository;
		}

		public async Task<Unit> Handle(CreateLeaveRequestCommand request, CancellationToken cancellationToken)
		{
			var leaveRequest = _mapper.Map<CleanArchitecture.Domain.LeaveRequest>(request);
			await _leaveRequestRepository.CreateAsync(leaveRequest);

			var email = new EmailMessage
			{
				To = string.Empty,
				Body = $"Your leave request for {request.StartDate:D} to {request.EndDate:D} " +
						$"has been submitted successfully.",
				Subject = "Leave Request Submitted"
			};

			await _emailSender.SendEmail(email);

			return Unit.Value;
		}
	}
}
