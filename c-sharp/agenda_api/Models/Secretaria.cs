namespace agenda_api.Models;

public class Secretaria{
	public Guid Id { get; set; }
	public Guid IdFuncionario { get; set; }
	public Funcionario Funcionario { get; set; }
	public Guid? IdSala { get; set; }

	public Secretaria(){}

	public Secretaria(Funcionario funcionario)
	{
		Id = Guid.NewGuid();
		IdFuncionario = funcionario.Id;
		Funcionario = funcionario;
	}
}