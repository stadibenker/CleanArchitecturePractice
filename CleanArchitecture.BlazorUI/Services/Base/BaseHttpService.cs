﻿using Blazored.LocalStorage;
using System.Net.Http.Headers;

namespace CleanArchitecture.BlazorUI.Services.Base
{
	public class BaseHttpService
	{
		protected readonly IClient _client;
		protected readonly ILocalStorageService _localStorage;

		public BaseHttpService(IClient client, ILocalStorageService localStorageService)
		{
			_client = client;
			_localStorage = localStorageService;
		}

		protected BaseResponse<Guid> ConvertApiExceptions<Guid>(ApiException ex)
		{
			if (ex.StatusCode == 400)
			{
				return new BaseResponse<Guid>() { Message = "Invalid data was submitted", ValidationErrors = ex.Response, Success = false };
			}
			else if (ex.StatusCode == 404)
			{
				return new BaseResponse<Guid>() { Message = "The record was not found.", Success = false };
			}
			else
			{
				return new BaseResponse<Guid>() { Message = "Something went wrong, please try again later.", Success = false };
			}
		}

		protected async Task AddBearerToken()
		{
			if (await _localStorage.ContainKeyAsync("token"))
				_client.HttpClient.DefaultRequestHeaders.Authorization =
					new AuthenticationHeaderValue("Bearer", await _localStorage.GetItemAsync<string>("token"));
		}
	}
}
