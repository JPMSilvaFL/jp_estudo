using System.ComponentModel.DataAnnotations;

namespace agenda_api.ViewModels;

public class EditorCargo {
	[Required] public string Nome { get; set; }
	[Required] public string Descricao { get; set; }
	[Required] public double Salario { get; set; }
}