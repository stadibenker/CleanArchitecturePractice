using CleanArchitecture.Domain;
using CleanArchitecture.Persistence.DatabaseContext;
using ClearArchitecture.Application.Contracts.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Persistence.Repositories
{
	public class LeaveTypeRepository : GenericRepository<LeaveType>, ILeaveTypeRepository
	{
		public LeaveTypeRepository(HrDbContext context) : base(context)
		{
		}

		public async Task<bool> IsLeaveTypeUnique(string name)
		{
			return await _context.LeaveTypes.AnyAsync(x => x.Name == name) == false;
		}
	}
}
