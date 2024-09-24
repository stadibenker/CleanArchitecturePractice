using AutoMapper;
using ClearArchitecture.Application.Contracts.Logging;
using ClearArchitecture.Application.Contracts.Persistence;
using ClearArchitecture.Application.Features.LeaveType.Commands.CreateLeaveType;
using ClearArchitecture.Application.Features.LeaveType.Queries.GetAllLeaveTypes;
using ClearArchitecture.Application.MappingProfiles;
using ClearArchitecture.UnitTests.Mocks;
using Moq;
using Shouldly;

namespace ClearArchitecture.UnitTests.Features.LeaveTypes.Commands
{
	public class CreateLeaveTypeCommandHandlerTests
	{
		private readonly Mock<ILeaveTypeRepository> _mockRepo;
		private readonly IMapper _mapper;
		private readonly Mock<IAppLogger<CreateLeaveTypeCommandHandler>> _mockLogger;
		
		public CreateLeaveTypeCommandHandlerTests()
		{
			_mockRepo = MockLeaveTypeRepository.GetMockLeaveTypeRepository();

			var mapperConfig = new MapperConfiguration(c =>
			{
				c.AddProfile<LeaveTypeProfile>();
			});
			_mapper = mapperConfig.CreateMapper();

			_mockLogger = new Mock<IAppLogger<CreateLeaveTypeCommandHandler>>();
		}

		[Fact]
		public async Task CreateLeaveTypeTest()
		{
			var handler = new CreateLeaveTypeCommandHandler(_mapper, _mockRepo.Object, _mockLogger.Object);

			var result = await handler.Handle(new CreateLeaveTypeCommand
			{
				DefaultDays = 15,
				Name = "Test 5"
			}, CancellationToken.None);

			result.ShouldBeOfType<int>();
			var allItems = await _mockRepo.Object.GetAsync();

			allItems.Count.ShouldBe(4);
		}
	}
}
