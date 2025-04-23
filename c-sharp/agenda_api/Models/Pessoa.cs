using agenda_api.Models.Notifications;

namespace agenda_api.Models;

public class Pessoa : Base {
	public Guid Id { set; get; }
	public string Cpf { get; set; }
	public string FullName { get; set; }
	public string Email { get; set; }
	public string Contato { get; set; }
	public bool IsActive { get; set; }
	public string Endereco { get; set; }
	public DateTime CreatedAt { set; get; }
	public DateTime? UpdatedAt { get; set; }

	public Pessoa(string cpf, string fullName, string email, string contato, string endereco)
	{
		if (VerificaCPF(cpf)) Cpf = ConverteCpf(cpf);
		if (verificaNome(fullName)) FullName = fullName;
		Email = email;
		Contato = contato;
		Endereco = endereco;
		CreatedAt = DateTime.UtcNow;
	}

	public Pessoa() { }

	public Pessoa(Guid id, string cpf, string email, string fullName, bool isActive, string contato, string endereco,
		DateTime createdAt, DateTime updatedAt)
	{
		Id = id;
		if (VerificaCPF(cpf)) Cpf = ConverteCpf(cpf);
		if (verificaNome(fullName) == true) FullName = fullName;
		Email = email;
		Contato = contato;
		Endereco = endereco;
		CreatedAt = createdAt;
		IsActive = isActive;
		UpdatedAt = updatedAt;
	}

	private string ConverteCpf(string cpf)
	{
		cpf = new string(cpf.Where(char.IsDigit).ToArray());
		return cpf;
	}

	private bool VerificaCPF(string cpf)
	{
		if (string.IsNullOrEmpty(cpf)) {
			AddNotification(new Notification("Cpf invalido", "Preencha corretamente o Cpf"));
			return false;
		}

		return true;
	}

	private bool verificaNome(string nome)
	{
		if (nome.Length < 10) {
			AddNotification(new Notification("Erro", "Nome precisa de ter mais que 10 caracteres"));
			return false;
		}

		return true;
	}
}