﻿using Microsoft.AspNetCore.Mvc;

namespace ClearArchitecture.Api.Models
{
	public class CustomProblemDetails : ProblemDetails
	{
		public IDictionary<string, string[]> Errors { get; set; } = new Dictionary<string, string[]>();
	}
}
