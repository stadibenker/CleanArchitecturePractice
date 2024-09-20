using AutoMapper;
using ClearArchitecture.Application.Contracts.Persistence;
using MediatR;

namespace ClearArchitecture.Application.Features.LeaveAllocation.Commands.CreateLeaveAllocation
{
	public class CreateLeaveAllocationCommandHandler : IRequestHandler<CreateLeaveAllocationCommand, Unit>
	{
		private readonly IMapper _mapper;
		private readonly ILeaveAllocationRepository _leaveAllocationRepository;
		private readonly ILeaveTypeRepository _leaveTypeRepository;

		public CreateLeaveAllocationCommandHandler(IMapper mapper,
			ILeaveAllocationRepository leaveAllocationRepository, ILeaveTypeRepository leaveTypeRepository)
		{
			_mapper = mapper;
			_leaveAllocationRepository = leaveAllocationRepository;
			_leaveTypeRepository = leaveTypeRepository;
		}

		public async Task<Unit> Handle(CreateLeaveAllocationCommand request, CancellationToken cancellationToken)
		{
			var leaveType = await _leaveTypeRepository.GetByIdAsync(request.LeaveTypeId);

			var leaveAllocation = _mapper.Map<CleanArchitecture.Domain.LeaveAllocation>(request);

			await _leaveAllocationRepository.CreateAsync(leaveAllocation);

			return Unit.Value;
		}
	}
}
