using AutoMapper;
using ClearArchitecture.Application.Contracts.Logging;
using ClearArchitecture.Application.Contracts.Persistence;
using ClearArchitecture.Application.Features.LeaveType.Queries.GetAllLeaveTypes;
using ClearArchitecture.Application.MappingProfiles;
using ClearArchitecture.UnitTests.Mocks;
using Moq;
using Shouldly;

namespace ClearArchitecture.UnitTests.Features.LeaveTypes.Queries
{
	public class GetLeaveTypesQueryHandlerTests
	{
		private readonly Mock<ILeaveTypeRepository> _mockRepo;
		private readonly IMapper _mapper;
		private readonly Mock<IAppLogger<GetLeaveTypesHandler>> _mockLogger;
		
		public GetLeaveTypesQueryHandlerTests()
		{
			_mockRepo = MockLeaveTypeRepository.GetMockLeaveTypeRepository();

			var mapperConfig = new MapperConfiguration(c =>
			{
				c.AddProfile<LeaveTypeProfile>();
			});
			_mapper = mapperConfig.CreateMapper();

			_mockLogger = new Mock<IAppLogger<GetLeaveTypesHandler>>();
		}

		[Fact]
		public async Task GetLeaveTypesTest()
		{
			var handler = new GetLeaveTypesHandler(_mapper, _mockRepo.Object, _mockLogger.Object);

			var result = await handler.Handle(new GetLeaveTypesQuery(), CancellationToken.None);

			result.ShouldBeOfType<List<LeaveTypeDto>>();
			result.Count.ShouldBe(3);
		}
	}
}
