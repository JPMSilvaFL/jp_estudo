using agenda_api.Data;
using Microsoft.EntityFrameworkCore;

namespace agenda_api.Collections.Repository;

	public class Repository<T> : IRepository<T> where T : class
	{
		private readonly DbSet<T> _dbSet;

		public Repository(AppDbContext context)
		{
			_dbSet = context.Set<T>();
		}

		public async Task<T> GetByIdAsync(int id)
		{
			return await _dbSet.FindAsync(id);
		}

		public async Task<IList<T>> GetAllAsync()
		{
			return await _dbSet
				.AsNoTracking()
				.ToListAsync();
		}

		public async Task AddAsync(T entity)
		{
			await _dbSet.AddAsync(entity);
		}

		public void Update(T entity)
		{
			_dbSet.Update(entity);
		}

		public async Task DeleteAsync(int id)
		{
			var entity = await _dbSet.FindAsync(id);
			if (entity != null)
			{
				_dbSet.Remove(entity);
			}
		}
	}
