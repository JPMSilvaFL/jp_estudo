using System.ComponentModel.DataAnnotations;

namespace agenda_api.ViewModels;

public class EditorAcesso {
	[Required] [MaxLength(40)] public string Nome { get; init; }
}