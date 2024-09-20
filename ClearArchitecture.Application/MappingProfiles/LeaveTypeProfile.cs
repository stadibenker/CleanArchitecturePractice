using AutoMapper;
using CleanArchitecture.Domain;
using ClearArchitecture.Application.Features.LeaveType.Commands.CreateLeaveType;
using ClearArchitecture.Application.Features.LeaveType.Commands.UpdateLeaveType;
using ClearArchitecture.Application.Features.LeaveType.Queries.GetAllLeaveTypes;
using ClearArchitecture.Application.Features.LeaveType.Queries.GetLeaveTypeDetails;

namespace ClearArchitecture.Application.MappingProfiles
{
	public class LeaveTypeProfile : Profile
	{
		public LeaveTypeProfile()
		{
			CreateMap<LeaveTypeDto, LeaveType>().ReverseMap();
			CreateMap<LeaveType, LeaveTypeDetailsDto>();
			CreateMap<CreateLeaveTypeCommand, LeaveType>();
			CreateMap<UpdateLeaveTypeCommand, LeaveType>();
		}
	}
}
