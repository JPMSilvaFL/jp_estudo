using agenda_api.Collections.Repository.Interfaces;
using agenda_api.Data;
using agenda_api.Models;
using Microsoft.EntityFrameworkCore;

namespace agenda_api.Collections.Repository;

public class UsuarioRepository : IUsuarioRepository {
	private readonly AppDbContext _context;
	private readonly DbSet<Usuario> _dbSet;

	public UsuarioRepository(AppDbContext context) {
		_context = context;
		_dbSet = context.Set<Usuario>();
	}


	public Task GetUserByPessoaId(Guid idPessoa) {
		return _dbSet
			.AsNoTracking()
			.Include(x=>x.PessoaId)
			.FirstOrDefaultAsync(x => x.Id == idPessoa);

	}

	public Task<Usuario> GetPerfilAcessoOfUsuario(Guid usuarioId) {
		throw new NotImplementedException();
	}
}