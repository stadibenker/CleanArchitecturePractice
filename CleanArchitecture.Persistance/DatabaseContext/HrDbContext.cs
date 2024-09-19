using CleanArchitecture.Domain;
using CleanArchitecture.Domain.Common;
using CleanArchitecture.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace CleanArchitecture.Persistence.DatabaseContext
{
	public class HrDbContext : DbContext
	{
		public HrDbContext(DbContextOptions<HrDbContext> options) : base(options) 
		{

		}

		public DbSet<LeaveType> LeaveTypes { get; set; }
		public DbSet<LeaveAllocation> LeaveAllocations { get; set; }
		public DbSet<LeaveRequest> LeaveRequests { get; set; }

		public DbSet<LeaveAllocation> Users { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfigurationsFromAssembly(typeof(HrDbContext).Assembly);

			base.OnModelCreating(modelBuilder);
		}

		public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
		{
			foreach (var entry in base.ChangeTracker.Entries<BaseEntity>()
				.Where(x => x.State == EntityState.Added || x.State == EntityState.Modified))
			{
				entry.Entity.DateModified = DateTime.Now;

				if (entry.State == EntityState.Added)
				{
					entry.Entity.DateCreated = DateTime.Now;
				}
			}
			return base.SaveChangesAsync(cancellationToken);
		}
	}
}
