using CleanArchitecture.Domain.Common;

namespace ClearArchitecture.Application.Contracts.Persistence
{
	// Very generic interface. For every table in database.
	public interface IGenericRepository<T> where T : BaseEntity
	{
		Task<IReadOnlyList<T>> GetAsync();
		Task<T> GetByIdAsync(int id);
		Task<T> CreateAsync(T entity);
		Task<int> UpdateAsync(T entity);
		Task DeleteAsync(T entity);
	}
}
