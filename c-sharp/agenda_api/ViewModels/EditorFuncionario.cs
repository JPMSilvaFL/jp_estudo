using System.ComponentModel.DataAnnotations;

namespace agenda_api.ViewModels;

public class EditorFuncionario {
	[Required] public Guid idPessoa { get; set; }
	[Required] public Guid idCargo { get; set; }
}