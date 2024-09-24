using AutoMapper;
using ClearArchitecture.Application.Contracts.Logging;
using ClearArchitecture.Application.Contracts.Persistence;
using ClearArchitecture.Application.Exceptions;
using ClearArchitecture.Application.Features.LeaveType.Queries.GetAllLeaveTypes;
using MediatR;

namespace ClearArchitecture.Application.Features.LeaveType.Commands.CreateLeaveType
{
	public class CreateLeaveTypeCommandHandler : IRequestHandler<CreateLeaveTypeCommand, int>
	{
		private readonly IMapper _mapper;
		private readonly ILeaveTypeRepository _repository;
		private readonly IAppLogger<CreateLeaveTypeCommandHandler> _logger;


		public CreateLeaveTypeCommandHandler(IMapper mapper ,ILeaveTypeRepository repository, IAppLogger<CreateLeaveTypeCommandHandler> logger)
		{
			_mapper = mapper;
			_repository = repository;
			_logger = logger;
		}

		public async Task<int> Handle(CreateLeaveTypeCommand request, CancellationToken cancellationToken)
		{
			var validator = new CreateLeaveTypeCommandValidator(_repository);
			var validationResult = await validator.ValidateAsync(request);

			if (validationResult.Errors.Any()) {
				_logger.LogWarning("Validation errors in create request for {0} - {1}", nameof(LeaveType), request.Name);
				throw new BadRequestException("Invalid LeaveType ", validationResult);
			}

			var leaveTypeToCreate = _mapper.Map<CleanArchitecture.Domain.LeaveType>(request);

			await _repository.CreateAsync(leaveTypeToCreate);

			return leaveTypeToCreate.Id;
		}
	}
}
