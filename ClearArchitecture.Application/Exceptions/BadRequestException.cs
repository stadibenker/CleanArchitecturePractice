using FluentValidation.Results;

namespace ClearArchitecture.Application.Exceptions
{
	public class BadRequestException : Exception
	{
		public BadRequestException(string message) : base(message)
		{

		}

		public BadRequestException(string message, ValidationResult validationResult) : base(message)
		{
			ValidationErrors = new List<string>();
			validationResult.Errors.ForEach(x => ValidationErrors.Add(x.ErrorMessage));
		}

		public List<string> ValidationErrors {  get; set; }
	}
}
