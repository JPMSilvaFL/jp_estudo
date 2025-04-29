namespace agenda_api.Collections.Repository.Interfaces;

public interface IUsuarioRepository {
	Task GetUserByPessoaId(Guid id);
}