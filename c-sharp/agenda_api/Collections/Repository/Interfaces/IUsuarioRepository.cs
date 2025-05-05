using agenda_api.Models;

namespace agenda_api.Collections.Repository.Interfaces;

public interface IUsuarioRepository : IRepository<Usuario> {
	Task<Usuario?> GetUsersByPessoaIdAsync(Guid pessoaId);
}