namespace Teste.Agendamento;

public class Funcionario {
	public Guid Id { get; set; }
	public Cargos Cargo { get; set; }
	public Person Pessoa { get; set; }
	public DateTime DataDeIngresso { set; get; }

	public Funcionario(Cargos cargo, Person pessoa)
	{
		Id = Guid.NewGuid();
		Cargo = cargo;
		Pessoa = pessoa;
		DataDeIngresso = DateTime.Now;
	}
}