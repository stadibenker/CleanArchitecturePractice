namespace ClearArchitecture.Application.Contracts.Persistence
{
	// Very generic interface. For every table in database.
	public interface IGenericRepository<T> where T : class
	{
		Task<ICollection<T>> GetAsync();
		Task<T> GetByIdAsync(int id);
		Task<T> CreateAsync(T entity);
		Task<T> UpdateAsync(T entity);
		Task DeleteAsync(T entity);
	}
}
