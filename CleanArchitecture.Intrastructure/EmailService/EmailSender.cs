using ClearArchitecture.Application.Contracts.Email;
using ClearArchitecture.Application.Models.Email;

namespace CleanArchitecture.Infrastructure.EmailService
{
	public class EmailSender : IEmailSender
	{
		public Task<bool> SendEmail(EmailMessage email)
		{
			throw new NotImplementedException();
		}
	}
}
