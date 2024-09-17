using CleanArchitecture.Domain;
using CleanArchitecture.Persistence.DatabaseContext;
using ClearArchitecture.Application.Contracts.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Persistence.Repositories
{
	public class LeaveRequestRepository : GenericRepository<LeaveRequest>, ILeaveRequestRepository
	{
		public LeaveRequestRepository(HrDbContext context) : base(context)
		{
		}

		public async Task<List<LeaveRequest>> GetLeaveRequestsWithDetails()
		{
			var leaveRequests = await _context.LeaveRequests
				.Include(x => x.LeaveType)
				.ToListAsync();
			return leaveRequests;
		}

		public async Task<List<LeaveRequest>> GetLeaveRequestsWithDetails(string userId)
		{
			var leaveRequests = await _context.LeaveRequests
				.Where(x => x.RequestingEmployeeId == userId)
				.Include(x => x.LeaveType)
				.ToListAsync();
			return leaveRequests;
		}

		public async Task<LeaveRequest> GetLeaveRequestWithDetails(int id)
		{
			var leaveRequest = await _context.LeaveRequests
				.Include(x => x.LeaveType)
				.FirstOrDefaultAsync(x => x.Id == id);
			return leaveRequest;
		}
	}
}
