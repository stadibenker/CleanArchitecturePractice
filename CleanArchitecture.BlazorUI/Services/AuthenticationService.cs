using Blazored.LocalStorage;
using CleanArchitecture.BlazorUI.Contracts;
using CleanArchitecture.BlazorUI.Providers;
using CleanArchitecture.BlazorUI.Services.Base;
using Microsoft.AspNetCore.Components.Authorization;

namespace HR.LeaveManagement.BlazorUI.Services
{
	public class AuthenticationService : BaseHttpService, IAuthenticationService
	{
		private readonly AuthenticationStateProvider _authenticationStateProvider;
		public AuthenticationService(IClient client,
			ILocalStorageService localStorage,
			AuthenticationStateProvider authenticationStateProvider) : base(client, localStorage)
		{
			_authenticationStateProvider = authenticationStateProvider;
		}

		public async Task<bool> AuthenticateAsync(string email, string password)
		{
			try
			{
				var authenticationResponse = await _client.LoginAsync(email, password);
				if (authenticationResponse.Token != string.Empty)
				{
					await _localStorage.SetItemAsync("token", authenticationResponse.Token);

					// Set claims in Blazor and login state
					await ((ApiAuthenticationStateProvider)_authenticationStateProvider).LoggedIn();
					return true;
				}
				return false;
			}
			catch (Exception)
			{
				return false;
			}

		}
		public async Task Logout()
		{
			await ((ApiAuthenticationStateProvider)_authenticationStateProvider).LoggedOut();
		}

		public async Task<bool> RegisterAsync(string firstName, string lastName, string userName, string email, string password)
		{
			var response = await _client.RegisterAsync(firstName, lastName, email, userName, password);

			if (!string.IsNullOrEmpty(response.UserId))
			{
				return true;
			}
			return false;
		}
	}
}