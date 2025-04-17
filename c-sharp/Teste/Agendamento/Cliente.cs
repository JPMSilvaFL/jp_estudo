namespace Teste.Agendamento;

internal class Cliente {
	public Guid Id { get; set; }
	public Person Pessoa { get; set; }

	public Cliente(Person pessoa)
	{
		Id = Guid.NewGuid();
		Pessoa = pessoa;
	}
}