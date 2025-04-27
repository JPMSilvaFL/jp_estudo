using agenda_api.Data;
using agenda_api.Models;
using agenda_api.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace agenda_api.Controllers;

[ApiController]
[Route("cargo")]
public class CargoController : ControllerBase {
	[HttpPost("create")]
	public async Task<IActionResult> Create([FromBody] EditorCargo cargo, [FromServices] AppDbContext context) {
		var cargoCriado = new Cargo(cargo.Nome, cargo.Descricao, cargo.Salario);

		await context.Cargos.AddAsync(cargoCriado);
		await context.SaveChangesAsync();
		return Ok(cargoCriado);
	}

	[HttpGet("lista")]
	public async Task<IActionResult> Lista([FromServices] AppDbContext context) {
		var cargos = await context.Cargos
			.AsNoTracking()
			.ToListAsync();
		return Ok(cargos);
	}
}