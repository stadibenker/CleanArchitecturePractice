﻿namespace CleanArchitecture.BlazorUI.Services.Base
{
	public class BaseResponse<T>
	{
		public string Message { get; set; }
		public string ValidationErrors { get; set; }
		public bool Success { get; set; }
		public T Data { get; set; }
	}
}
