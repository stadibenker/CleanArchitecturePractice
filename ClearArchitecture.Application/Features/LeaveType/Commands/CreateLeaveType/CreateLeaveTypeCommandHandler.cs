using AutoMapper;
using ClearArchitecture.Application.Contracts.Persistence;
using ClearArchitecture.Application.Exceptions;
using MediatR;

namespace ClearArchitecture.Application.Features.LeaveType.Commands.CreateLeaveType
{
	public class CreateLeaveTypeCommandHandler : IRequestHandler<CreateLeaveTypeCommand, int>
	{
		private readonly IMapper _mapper;
		private readonly ILeaveTypeRepository _repository;

		public CreateLeaveTypeCommandHandler(IMapper mapper ,ILeaveTypeRepository repository)
		{
			_mapper = mapper;
			_repository = repository;
		}

		public async Task<int> Handle(CreateLeaveTypeCommand request, CancellationToken cancellationToken)
		{
			var validator = new CreateLeaveTypeCommandValidator(_repository);
			var validationResult = await validator.ValidateAsync(request);

			if (!validationResult.Errors.Any()) {
				throw new BadRequestException("Invalid LeaveType ", validationResult);
			}

			var leaveTypeToCreate = _mapper.Map<CleanArchitecture.Domain.LeaveType>(request);

			await _repository.CreateAsync(leaveTypeToCreate);

			return leaveTypeToCreate.Id;
		}
	}
}
