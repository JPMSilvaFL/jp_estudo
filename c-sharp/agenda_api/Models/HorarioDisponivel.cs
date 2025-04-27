namespace agenda_api.Models;

public class HorarioDisponivel {
	public Guid Id { get; set; }
	public Guid IdFuncionario { get; set; }
	public Funcionario Funcionario { get; set; }
	public bool Reservado { get; set; }
	public DateTime Horario { get; set; }

	public HorarioDisponivel() { }

	public HorarioDisponivel(Funcionario funcionario, DateTime horario) {
		Id = Guid.NewGuid();
		IdFuncionario = funcionario.Id;
		Funcionario = funcionario;
		Reservado = false;
		Horario = horario;
	}
}