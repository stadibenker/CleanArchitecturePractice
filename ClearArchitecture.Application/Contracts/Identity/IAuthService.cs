using ClearArchitecture.Application.Models.Identity;

namespace ClearArchitecture.Application.Contracts.Identity
{
	public interface IAuthService
	{
		Task<AuthResponse> Login (AuthRequest request);
		Task<RegistrationResponse> Register (RegistrationRequest request);
	}
}
