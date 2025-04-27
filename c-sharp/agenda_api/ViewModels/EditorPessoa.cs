using System.ComponentModel.DataAnnotations;

namespace agenda_api.ViewModels;

public class EditorPessoa {
	[Required]
	[MinLength(11)]
	[MaxLength(11)]
	public string Cpf { get; set; }

	[Required]
	[MinLength(3)]
	[MaxLength(100)]
	public string FullName { get; set; }

	[EmailAddress] [Required] public string Email { get; set; }
	[Required] [Phone] public string Contato { get; set; }

	[Required]
	[MinLength(20)]
	[MaxLength(150)]
	public string Endereco { get; set; }
}