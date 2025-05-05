using agenda_api.Collections.Repository.Interfaces;
using agenda_api.Data;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace agenda_api.Collections.Repository;

public class Repository<T> : IRepository<T> where T : class {
	private readonly AppDbContext _context;
	private readonly DbSet<T> _dbSet;

	public Repository(AppDbContext context) {
		_context = context;
		_dbSet = context.Set<T>();
	}

	protected Repository() { }

	public async Task<T> GetByIdAsync(Guid id) {
		var result = await _dbSet.FindAsync(id);
		return result;
	}

	public async Task<IList<T>> GetAllAsync() {
		return await _dbSet
			.AsNoTracking()
			.ToListAsync();
	}

	public async Task AddAsync(T entity) {
		await _dbSet.AddAsync(entity);
	}

	public void Update(T entity) {
		_dbSet.Update(entity);
	}

	public async Task DeleteAsync(Guid id) {
		var entity = await _dbSet.FindAsync(id);
		if (entity != null) _dbSet.Remove(entity);
	}

	public void DeleteAll() {
		_dbSet.RemoveRange(_dbSet);
	}

	public async Task SaveChangesAsync() {
		await _context.SaveChangesAsync();
	}
}