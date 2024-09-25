using CleanArchitecture.BlazorUI.Models.LeaveTypes;
using CleanArchitecture.BlazorUI.Services.Base;

namespace CleanArchitecture.BlazorUI.Contracts
{
	public interface ILeaveTypeService
	{
		Task<List<LeaveTypeVM>> GetLeaveTypes();
		Task<LeaveTypeVM> GetLeaveTypeDetails(int id);
		Task<BaseResponse<Guid>> CreateLeaveType(LeaveTypeVM leaveType);
		Task<BaseResponse<Guid>> UpdateLeaveType(int id, LeaveTypeVM leaveType);
		Task<BaseResponse<Guid>> DeleteLeaveType(int id);
	}
}
