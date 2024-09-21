using AutoMapper;
using CleanArchitecture.Domain;
using ClearArchitecture.Application.Features.LeaveRequest.Commands.CreateLeaveRequest;
using ClearArchitecture.Application.Features.LeaveRequest.Commands.UpdateRequest;
using ClearArchitecture.Application.Features.LeaveRequest.Queries.GetLeaveRequestDetails;
using ClearArchitecture.Application.Features.LeaveRequest.Queries.GetLeaveRequestList;

namespace ClearArchitecture.Application.MappingProfiles
{
	public class LeaveRequestProfile : Profile
	{
		public LeaveRequestProfile()
		{
			CreateMap<LeaveRequestDto, LeaveRequest>().ReverseMap();
			CreateMap<LeaveRequest, LeaveRequestDetailsDto>();
			CreateMap<CreateLeaveRequestCommand, LeaveRequest>();
			CreateMap<UpdateLeaveRequestCommand, LeaveRequest>();
		}
	}
}
