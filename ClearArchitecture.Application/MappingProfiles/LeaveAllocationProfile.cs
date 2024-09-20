using AutoMapper;
using CleanArchitecture.Domain;
using ClearArchitecture.Application.Features.LeaveAllocation.Commands.CreateLeaveAllocation;
using ClearArchitecture.Application.Features.LeaveAllocation.Commands.UpdateLeaveAllocation;
using ClearArchitecture.Application.Features.LeaveAllocation.Queries.GetLeaveAllocationDetails;
using ClearArchitecture.Application.Features.LeaveAllocation.Queries.GetLeaveAllocations;

namespace ClearArchitecture.Application.MappingProfiles
{
	public class LeaveAllocationProfile : Profile
	{
		public LeaveAllocationProfile()
		{
			CreateMap<LeaveAllocationDto, LeaveAllocation>().ReverseMap();
			CreateMap<LeaveAllocation, LeaveAllocationDetailsDto>();
			CreateMap<CreateLeaveAllocationCommand, LeaveAllocation>();
			CreateMap<UpdateLeaveAllocationCommand, LeaveAllocation>();
		}
	}
}
