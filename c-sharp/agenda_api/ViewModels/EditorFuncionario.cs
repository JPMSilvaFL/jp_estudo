using System.ComponentModel.DataAnnotations;

namespace agenda_api.ViewModels;

public class EditorFuncionario {
	[Required] public Guid IdPessoa { get; set; }
	[Required] public Guid IdCargo { get; set; }
}