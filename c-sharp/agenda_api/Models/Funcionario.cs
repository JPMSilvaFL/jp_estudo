namespace agenda_api.Models;

public class Funcionario{
	public Guid Id { get; set; }
	public Guid CargoId { get; set; }
	public Cargo? Cargo { get; set; }
	public Guid PessoaId { get; set; }
	public Pessoa? Pessoa { get; set; }
	public DateTime DataDeIngresso { set; get; }

	public Funcionario() { }

	public Funcionario(Cargo cargo, Pessoa pessoa) {
		Id = Guid.NewGuid();
		Cargo = cargo;
		Pessoa = pessoa;
		DataDeIngresso = DateTime.UtcNow;
		CargoId = cargo.Id;
		PessoaId = pessoa.Id;
	}

	public Funcionario(Guid cargoId, Guid pessoaId) {
		Id = Guid.NewGuid();
		CargoId = cargoId;
		PessoaId = pessoaId;
		DataDeIngresso = DateTime.UtcNow;
	}
}