﻿using CleanArchitecture.Domain.Common;
using CleanArchitecture.Persistence.DatabaseContext;
using ClearArchitecture.Application.Contracts.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Persistence.Repositories
{
	public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
	{
		protected readonly HrDbContext _context;

		public GenericRepository(HrDbContext context)
		{
			_context = context;
		}

		public async Task<T> CreateAsync(T entity)
		{
			await _context.AddAsync(entity);
			await _context.SaveChangesAsync();
			return entity;
		}

		public async Task DeleteAsync(T entity)
		{
			_context.Remove(entity);
			await _context.SaveChangesAsync();
		}

		public async Task<IReadOnlyList<T>> GetAsync()
		{
			return await _context.Set<T>().AsNoTracking().ToListAsync();
		}

		public async Task<T> GetByIdAsync(int id)
		{
			return await _context.Set<T>().AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
		}

		public async Task<int> UpdateAsync(T entity)
		{
			_context.Entry(entity).State = EntityState.Modified;
			return await _context.SaveChangesAsync();
		}
	}
}
