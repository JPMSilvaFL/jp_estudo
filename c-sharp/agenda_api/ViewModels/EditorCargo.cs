using System.ComponentModel.DataAnnotations;

namespace agenda_api.ViewModels;

public class EditorCargo {
	[Required] [MaxLength(30)] public string Nome { get; set; }
	[Required] [MaxLength(100)] public string Descricao { get; set; }
	[Required] public double Salario { get; set; }
}