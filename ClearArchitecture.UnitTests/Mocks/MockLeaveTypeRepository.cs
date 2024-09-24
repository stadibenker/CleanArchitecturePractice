using CleanArchitecture.Domain;
using ClearArchitecture.Application.Contracts.Persistence;
using Moq;

namespace ClearArchitecture.UnitTests.Mocks
{
	public class MockLeaveTypeRepository
	{
		public static Mock<ILeaveTypeRepository> GetMockLeaveTypeRepository()
		{
			var leaveTypes = new List<LeaveType>
			{
				new LeaveType
				{
					Id = 1,
					DefaultDays = 10,
					Name = "Test 1"
				},
				new LeaveType
				{
					Id = 2,
					DefaultDays = 20,
					Name = "Test 2"
				},
				new LeaveType
				{
					Id = 3,
					DefaultDays = 30,
					Name = "Test 3"
				}
			};

			var mockRepo = new Mock<ILeaveTypeRepository>();

			mockRepo.Setup(x => x.GetAsync()).ReturnsAsync(leaveTypes);

			mockRepo.Setup(x => x.CreateAsync(It.IsAny<LeaveType>()))
				.Returns((LeaveType leaveType) =>
				{
					leaveTypes.Add(leaveType);
					return Task.FromResult(leaveType);
				});

			mockRepo.Setup(x => x.IsLeaveTypeUnique(It.IsAny<string>()))
				.Returns((string leaveTypeName) =>
				{
					var exists = leaveTypes.Any(x => x.Name == leaveTypeName);
					return Task.FromResult(!exists);
				});

			return mockRepo;
		}
	}
}
