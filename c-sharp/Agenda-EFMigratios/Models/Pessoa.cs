using Agenda_EFMigratios.Models.Notifications;

namespace Agenda_EFMigratios.Models;

public class Pessoa : Base {
	public Guid Id { set; get; }
	public string Cpf { get; set; }
	public string FullName { get; set; }
	public string Email { get; set; }
	public string Contato { get; set; }
	public bool IsActive { get; set; }
	public string Endereco { get; set; }
	public DateTime CreatedAt { set; get; }
	public DateTime UpdatedAt { get; set; }

	public Pessoa(string cpf, string nome, string email, string contato, string endereco)
	{
		Id = Guid.NewGuid();
		Cpf = VerificaCPF(cpf);
		FullName = nome;
		Email = email;
		Contato = contato;
		Endereco = endereco;
		CreatedAt = DateTime.Now;
		IsActive = true;
	}

	public Pessoa() { }

	public Pessoa(Guid id, string cpf, string email, string fullName, bool isActive, string contato, string endereco,
		DateTime createdAt, DateTime updatedAt)
	{
		Id = id;
		Cpf = cpf;
		FullName = fullName;
		Email = email;
		Contato = contato;
		Endereco = endereco;
		CreatedAt = createdAt;
		IsActive = isActive;
		UpdatedAt = updatedAt;
	}

	private string VerificaCPF(string cpf)
	{
		if (string.IsNullOrEmpty(cpf))
			throw new Exception(
				"Preencha corretamente o Cpf");

		cpf = new string(cpf.Where(char.IsDigit).ToArray());
		return cpf;
	}

	private bool verificaNome(string nome)
	{
		if (nome.Length > 10)
			return true;
		else
			AddNotification(new Notification("Erro",
				"Nome precisa de ter mais que 10 caracteres"));
		return false;
	}
}