namespace agenda_api.Models;

public class PerfilAcesso {
	public Guid Id { get; init; }
	public string Nome { get; init; }

	public PerfilAcesso() { }

	public PerfilAcesso(string nome) {
		Id = Guid.NewGuid();
		Nome = nome;
	}
}