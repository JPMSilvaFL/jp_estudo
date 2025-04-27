namespace agenda_api.Models;

public class Atendimento {
	public Guid Id { get; set; }
	public Guid IdCliente { get; set; }
	public Cliente Cliente { get; set; }
	public Guid IdFuncionario { get; set; }
	public Funcionario Funcionario { get; set; }
	public Guid IdSecretaria { get; set; }
	public Secretaria Secretaria { get; set; }
	public Guid IdHorario { get; set; }
	public HorarioDisponivel HorarioDisponivel { get; set; }

	public Atendimento() { }

	public Atendimento(Cliente cliente, Funcionario funcionario, Secretaria secretaria, HorarioDisponivel horario) {
		Id = Guid.NewGuid();
		IdCliente = cliente.Id;
		Cliente = cliente;
		IdFuncionario = funcionario.Id;
		Funcionario = funcionario;
		IdSecretaria = secretaria.Id;
		Secretaria = secretaria;
		IdHorario = horario.Id;
		HorarioDisponivel = horario;
	}
}