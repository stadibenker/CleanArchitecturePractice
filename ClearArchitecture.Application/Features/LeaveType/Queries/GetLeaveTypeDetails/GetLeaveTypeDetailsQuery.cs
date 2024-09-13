﻿using MediatR;

namespace ClearArchitecture.Application.Features.LeaveType.Queries.GetLeaveTypeDetails
{
	public record GetLeaveTypeDetailsQuery(int Id) : IRequest<LeaveTypeDetailsDto>;
}
