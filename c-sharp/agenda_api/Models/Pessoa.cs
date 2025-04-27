namespace agenda_api.Models;

public class Pessoa {
	public Guid Id { set; get; }
	public string Cpf { get; set; }
	public string FullName { get; set; }
	public string Email { get; set; }
	public string Contato { get; set; }
	public bool IsActive { get; set; }
	public string Endereco { get; set; }
	public DateTime CreatedAt { set; get; }
	public DateTime? UpdatedAt { get; set; }

	public Pessoa(string cpf, string fullName, string email, string contato, string endereco) {
		Cpf = ConverteCpf(cpf);
		FullName = fullName;
		Email = email;
		Contato = contato;
		Endereco = endereco;
		CreatedAt = DateTime.UtcNow;
		IsActive = true;
	}

	public Pessoa() { }

	public Pessoa(Guid id, string cpf, string email, string fullName, bool isActive, string contato, string endereco,
		DateTime createdAt, DateTime updatedAt) {
		Id = id;
		Cpf = ConverteCpf(cpf);
		FullName = fullName;
		Email = email;
		Contato = contato;
		Endereco = endereco;
		CreatedAt = createdAt;
		IsActive = isActive;
		UpdatedAt = updatedAt;
	}

	private string ConverteCpf(string cpf) {
		cpf = new string(cpf.Where(char.IsDigit).ToArray());
		return cpf;
	}
}