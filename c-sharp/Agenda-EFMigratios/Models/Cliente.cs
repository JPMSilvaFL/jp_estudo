namespace Agenda_EFMigratios.Models;

public class Cliente {
	public Guid Id { get; set; }
	public Guid PessoaId { get; set; }
	public Pessoa Pessoa { get; set; }
	public DateTime CreatedAt { get; set; }

	public Cliente() { }

	public Cliente(Pessoa pessoa)
	{
		Id = Guid.NewGuid();
		Pessoa = pessoa;
		CreatedAt = DateTime.UtcNow;
		PessoaId = pessoa.Id;
	}
}