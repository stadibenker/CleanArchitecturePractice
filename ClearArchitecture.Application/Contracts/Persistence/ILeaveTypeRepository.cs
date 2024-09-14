using CleanArchitecture.Domain;

namespace ClearArchitecture.Application.Contracts.Persistence
{
	public interface ILeaveTypeRepository : IGenericRepository<LeaveType>
	{
		Task<bool> IsLeaveTypeUnique(string name);
	}
}
