using CleanArchitecture.Domain;
using CleanArchitecture.Persistence.DatabaseContext;
using ClearArchitecture.Application.Contracts.Persistence;

namespace CleanArchitecture.Persistence.Repositories
{
	public class LeaveRequestRepository : GenericRepository<LeaveRequest>, ILeaveRequestRepository
	{
		public LeaveRequestRepository(HrDbContext context) : base(context)
		{
		}
	}
}
