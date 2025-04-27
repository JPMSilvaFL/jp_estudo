using agenda_api.Data;
using agenda_api.Models;
using agenda_api.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace agenda_api.Controllers;

[ApiController]
[Route("funcionario")]
public class FuncionarioController : ControllerBase {
	[HttpPost("create")]
	public async Task<IActionResult> Post([FromBody] EditorFuncionario create, [FromServices] AppDbContext context) {
		var pessoa = await context.Pessoas.FindAsync(create.idPessoa);
		if (pessoa == null)
			return NotFound("Pessoa nao encontrada");
		var cargo = await context.Cargos.FindAsync(create.idCargo);
		if (cargo == null)
			return NotFound("Cargo nao encontrado");

		var funcionarioCriado = new Funcionario(cargo, pessoa);
		context.Funcionarios.Add(funcionarioCriado);
		await context.SaveChangesAsync();
		return Ok(funcionarioCriado);
	}
}