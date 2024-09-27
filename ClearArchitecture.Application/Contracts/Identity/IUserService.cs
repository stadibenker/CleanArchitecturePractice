using ClearArchitecture.Application.Models.Identity;

namespace ClearArchitecture.Application.Contracts.Identity
{
	public interface IUserService
	{
		Task<List<Employee>> GetEmployees();
		Task<Employee> GetEmployee(string userId);
	}
}
