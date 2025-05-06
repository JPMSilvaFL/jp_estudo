using agenda_api.Collections.Repository.Interfaces;
using agenda_api.Data;
using agenda_api.Models;
using Microsoft.EntityFrameworkCore;

namespace agenda_api.Collections.Repository;

public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository {
	private readonly AppDbContext _context;
	private readonly DbSet<Usuario> _dbSet;

	public UsuarioRepository(AppDbContext context) {
		_context = context;
		_dbSet = context.Set<Usuario>();
	}

	public async Task<Usuario> GetUsersByPessoaIdAsync(Guid pessoaId) {
		return await _dbSet
			.AsNoTracking()
			.FirstOrDefaultAsync(x => x.PessoaId == pessoaId);
	}
}