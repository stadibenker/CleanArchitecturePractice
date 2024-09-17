using ClearArchitecture.Application.Models.Email;

namespace ClearArchitecture.Application.Contracts.Email
{
	public interface IEmailSender
	{
		Task<bool> SendEmail(EmailMessage email);
	}
}
