namespace Teste.Agendamento;

public class Cargos {
	public Guid Id { get; set; }
	public string Nome { get; set; }
	public string Descricao { get; set; }
	public double Salario { get; set; }

	public Cargos() { }

	public Cargos(string nome, string descricao, double salario)
	{
		Id = Guid.NewGuid();
		Nome = nome;
		Descricao = descricao;
		Salario = salario;
	}
}