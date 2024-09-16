using CleanArchitecture.Domain;
using CleanArchitecture.Persistence.DatabaseContext;
using ClearArchitecture.Application.Contracts.Persistence;

namespace CleanArchitecture.Persistence.Repositories
{
	public class LeaveAllocationRepository : GenericRepository<LeaveAllocation>, ILeaveAllocationRepository
	{
		public LeaveAllocationRepository(HrDbContext context) : base(context)
		{
		}
	}
}
