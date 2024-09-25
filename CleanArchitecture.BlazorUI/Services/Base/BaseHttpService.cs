namespace CleanArchitecture.BlazorUI.Services.Base
{
	public class BaseHttpService
	{
		protected IClient _client;

		public BaseHttpService(IClient client)
		{
			_client = client;
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
	}
}
