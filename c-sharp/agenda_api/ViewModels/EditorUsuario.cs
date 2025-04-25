using System.ComponentModel.DataAnnotations;

namespace agenda_api.ViewModels;

public class EditorUsuario {
	public string? Cpf { get; set; }
	public string? FullName { get; set; }
	public string? Email { get; set; }
	public string? Contato { get; set; }
	public string? Endereco { get; set; }
	public Guid? PessoaId { get; set; }
	[Required] public Guid IdAcesso { get; set; }

	[Required] [MaxLength(50)] public string Username { get; set; }
	[Required] public string Password { get; set; }
}