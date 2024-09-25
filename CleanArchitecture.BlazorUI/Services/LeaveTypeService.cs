using AutoMapper;
using CleanArchitecture.BlazorUI.Contracts;
using CleanArchitecture.BlazorUI.Models.LeaveTypes;
using CleanArchitecture.BlazorUI.Services.Base;

namespace CleanArchitecture.BlazorUI.Services
{
	public class LeaveTypeService : BaseHttpService, ILeaveTypeService
	{
		private readonly IMapper _mapper;
		
		public LeaveTypeService(IClient client, IMapper mapper) : base(client)
		{
			_mapper = mapper;
		}

		public async Task<List<LeaveTypeVM>> GetLeaveTypes()
		{
			var data = await _client.LeaveTypesAllAsync();

			return _mapper.Map<List<LeaveTypeVM>>(data);
		}

		public async Task<LeaveTypeVM> GetLeaveTypeDetails(int id)
		{
			var data = await _client.LeaveTypesGETAsync(id);

			return _mapper.Map<LeaveTypeVM>(data);
		}

		public async Task<BaseResponse<Guid>> CreateLeaveType(LeaveTypeVM leaveType)
		{
			try
			{
				var createLeaveTypeCommand = _mapper.Map<CreateLeaveTypeDto>(leaveType);
				await _client.LeaveTypesPOSTAsync(createLeaveTypeCommand);
				return new BaseResponse<Guid>()
				{
					Success = true,
				};
			}
			catch (ApiException ex)
			{
				return ConvertApiExceptions<Guid>(ex);
			}
		}

		public async Task<BaseResponse<Guid>> UpdateLeaveType(int id, LeaveTypeVM leaveType)
		{
			try
			{
				var updateLeaveTypeCommand = _mapper.Map<UpdateLeaveTypeDto>(leaveType);
				await _client.LeaveTypesPUTAsync(id, updateLeaveTypeCommand);
				return new BaseResponse<Guid>()
				{
					Success = true,
				};
			}
			catch (ApiException ex)
			{
				return ConvertApiExceptions<Guid>(ex);
			}
		}

		public async Task<BaseResponse<Guid>> DeleteLeaveType(int id)
		{
			try
			{
				await _client.LeaveTypesDELETEAsync(id);
				return new BaseResponse<Guid>() { Success = true };
			}
			catch (ApiException ex)
			{
				return ConvertApiExceptions<Guid>(ex);
			}
		}
	}
}
