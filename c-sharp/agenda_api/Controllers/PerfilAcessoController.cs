using agenda_api.Data;
using agenda_api.Models;
using agenda_api.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace agenda_api.Controllers;

[ApiController]
[Route("acesso")]
public class PerfilAcessoController : ControllerBase {
	[HttpPost("create")]
	public async Task<IActionResult> Criar([FromBody] EditorAcesso acesso, [FromServices] AppDbContext context) {
		var acessoCriado = new PerfilAcesso(acesso.Nome);
		await context.AddAsync(acessoCriado);
		await context.SaveChangesAsync();

		return Ok(acessoCriado);
	}

	[HttpGet("lista")]
	public async Task<IActionResult> Lista([FromServices] AppDbContext context) {
		var listaAcessos = await context.PerfilAcessos
			.ToListAsync();

		return Ok(listaAcessos);
	}
}