namespace agenda_api.Models;

public class LogAtividade {
	public Guid Id { get; set; }
	public string Categoria { get; set; }
	public string Descricao { get; set; }
	public DateTime CreatedAt { get; set; }

	public LogAtividade(string categoria, string descricao) {
		Categoria = categoria;
		Descricao = descricao;
		Id = Guid.NewGuid();
		CreatedAt = DateTime.UtcNow;
	}
}