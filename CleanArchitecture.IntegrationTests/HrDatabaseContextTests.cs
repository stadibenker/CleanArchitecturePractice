using CleanArchitecture.Domain;
using CleanArchitecture.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using Shouldly;

namespace CleanArchitecture.IntegrationTests
{
	public class HrDatabaseContextTests
	{
		private readonly HrDbContext _hrDbContext;

		public HrDatabaseContextTests()
		{
			var dbOptions = new DbContextOptionsBuilder<HrDbContext>()
				.UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;

			_hrDbContext = new HrDbContext(dbOptions);
		}

		[Fact]
		public async void SaveSetDateCreatedAndModifiedValue()
		{
			var leaveType = new LeaveType
			{
				Id = 1,
				DefaultDays = 10,
				Name = "Test 1"
			};

			await _hrDbContext.LeaveTypes.AddAsync(leaveType);
			await _hrDbContext.SaveChangesAsync();

			leaveType.DateCreated.ShouldNotBeNull();
			leaveType.DateModified.ShouldNotBeNull();
		}
	}
}
