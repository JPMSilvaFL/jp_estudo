using System.ComponentModel.DataAnnotations;
using agenda_api.Models;

namespace agenda_api.ViewModels;

public class EditorCliente {
	[Required] public Guid PessoaId { get; set; }
}