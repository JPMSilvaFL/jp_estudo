namespace agenda_api.Models;

public class Secretaria{
	public Guid Id { get; set; }
	public Guid IdFuncionario { get; set; }
	public Funcionario? Funcionario { get; set; }
	public Guid? IdSala { get; set; }

	public Secretaria(){}

	public Secretaria(Guid idFuncionario)
	{
		Id = Guid.NewGuid();
		IdFuncionario = idFuncionario;
	}
}