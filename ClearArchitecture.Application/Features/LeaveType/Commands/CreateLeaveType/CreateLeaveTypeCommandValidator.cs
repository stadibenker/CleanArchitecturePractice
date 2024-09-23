using ClearArchitecture.Application.Contracts.Persistence;
using FluentValidation;

namespace ClearArchitecture.Application.Features.LeaveType.Commands.CreateLeaveType
{
	public class CreateLeaveTypeCommandValidator : AbstractValidator<CreateLeaveTypeCommand>
	{
		private readonly ILeaveTypeRepository _repository;

		public CreateLeaveTypeCommandValidator(ILeaveTypeRepository repository)
		{
			_repository = repository;
			SetupRules();
		}

		private void SetupRules()
		{
			RuleFor(x => x.Name)
				.NotEmpty().WithMessage("{PropertyName} is required")
				.NotNull()
				.MaximumLength(70).WithMessage("{PropertyName} must be fewer than 70 characters");

			RuleFor(x => x.DefaultDays)
				.LessThan(100).WithMessage("{PropertyName} cannot be greater than 100")
				.GreaterThan(1).WithMessage("{PropertyName} cannot be less than 1");

			RuleFor(x => x)
				.MustAsync(LeaveTypeNameUnique)
				.WithMessage("Leave type already exists")
				.WithName("Leave type");
		}

		private async Task<bool> LeaveTypeNameUnique(CreateLeaveTypeCommand command, CancellationToken token)
		{
			return await _repository.IsLeaveTypeUnique(command.Name);
		}
	}
}
