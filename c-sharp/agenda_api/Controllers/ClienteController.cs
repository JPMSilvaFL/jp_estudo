using agenda_api.Data;
using agenda_api.Models;
using agenda_api.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace agenda_api.Controllers;

[ApiController]
[Route("cliente")]
public class ClienteController : ControllerBase {
	[HttpGet("lista")]
	public async Task<IActionResult> ListaClientes([FromServices] AppDbContext context) {
		var clientes = await context.Clientes
			.AsNoTracking()
			.Include(p => p.Pessoa)
			.Where(p => p.Pessoa.IsActive == true)
			.ToListAsync();
		return Ok(clientes);
	}

	[HttpPost("createcliente")]
	public async Task<IActionResult> CadastraCliente([FromBody] EditorCliente cliente, [FromServices] AppDbContext context) {
		var pessoa = await context.Pessoas.FindAsync(cliente.PessoaId);
		var clienteCriado = new Cliente(pessoa);

		await context.Clientes.AddAsync(clienteCriado);
		await context.SaveChangesAsync();
		return Ok(clienteCriado);
	}
}