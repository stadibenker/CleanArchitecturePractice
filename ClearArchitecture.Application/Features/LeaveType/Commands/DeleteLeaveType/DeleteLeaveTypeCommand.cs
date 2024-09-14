﻿using MediatR;

namespace ClearArchitecture.Application.Features.LeaveType.Commands.DeleteLeaveType
{
	public class DeleteLeaveTypeCommand : IRequest<Unit>
	{
		public int Id { get; set; }
	}
}
