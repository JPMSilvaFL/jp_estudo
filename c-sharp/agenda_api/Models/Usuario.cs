namespace agenda_api.Models;

public class Usuario {
	public Guid Id { get; set; }
	public string Username { get; set; }
	public string Password { get; set; }
	public Guid PessoaId { get; set; }
	public Pessoa Pessoa { get; set; }
	public Guid PerfilAcessoId { get; set; }
	public PerfilAcesso? Acesso { get; set; }
	private IList<LogAtividade> Log { get; set; } = new List<LogAtividade>();
	public DateTime CreatedAt { get; set; }

	public Usuario() { }

	public Usuario(PerfilAcesso perfilAcesso, Pessoa pessoa, string username, string password) {
		Id = Guid.NewGuid();
		Acesso = perfilAcesso;
		CreatedAt = DateTime.UtcNow;
		Pessoa = pessoa;
		Username = username;
		Password = password;
	}

	public void AdicionarAtividade(LogAtividade log) {
		Log.Add(log);
	}
}