using agenda_api.Models;

namespace agenda_api.Collections.Repository.Interfaces;

public interface IUsuarioRepository {
	Task<Usuario?> GetUsersByPessoaIdAsync(Guid pessoaId);
}