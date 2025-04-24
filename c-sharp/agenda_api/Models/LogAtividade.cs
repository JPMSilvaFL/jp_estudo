namespace agenda_api.Models;

public class LogAtividade {
	public Guid Id { get; set; }
	public Guid IdPessoa { get; set; }
	public Pessoa Pessoa { get; set; }
	public string Categoria { get; set; }
	public string Descricao { get; set; }
	public DateTime CreatedAt { get; set; }

	public LogAtividade() { }

	public LogAtividade(string categoria, string descricao, Pessoa pessoa) {
		Categoria = categoria;
		Descricao = descricao;
		Id = Guid.NewGuid();
		CreatedAt = DateTime.UtcNow;
		Pessoa = pessoa;
		IdPessoa = pessoa.Id;
	}
}