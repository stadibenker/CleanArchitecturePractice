﻿using System.ComponentModel.DataAnnotations;

namespace CleanArchitecture.BlazorUI.Models.LeaveTypes
{
	public class LeaveTypeVM
	{
		public int Id { get; set; }
		
		[Required]
		public string Name { get; set; }

		[Required]
		[Display(Name = "Default number of days")]
		public int DefaultDays { get; set; }
	}
}
