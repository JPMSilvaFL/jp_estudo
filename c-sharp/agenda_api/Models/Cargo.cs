namespace Agenda_EFMigratios.Models;

public class Cargo {
	public Guid Id { get; set; }
	public string Nome { get; set; }
	public string Descricao { get; set; }
	public double Salario { get; set; }

	public Cargo() { }

	public Cargo(string nome, string descricao, double salario)
	{
		Id = Guid.NewGuid();
		Nome = nome;
		Descricao = descricao;
		Salario = salario;
	}
}