using agenda_api.Data;
using agenda_api.Models;
using agenda_api.ViewModels;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace agenda_api.Controllers;

[Route("pessoa")]
public class PessoaController : ControllerBase {
	[HttpGet("lista")]
	public async Task<IActionResult> GetAll([FromServices] AppDbContext context) {
		var pessoas = context.Pessoas.ToList();
		if (pessoas.Count == 0)
			return BadRequest("Nenhuma pessoa foi encontrada");

		return Ok(pessoas);
	}

	[HttpPost("Create")]
	public async Task<IActionResult> Post([FromBody] EditorPessoa pessoa, [FromServices] AppDbContext context) {
		var person = new Pessoa(pessoa.Cpf, pessoa.FullName, pessoa.Email, pessoa.Contato, pessoa.Endereco);

		if (person.Notifications.Count > 0)
			return BadRequest(person.Notifications);

		await context.Pessoas.AddAsync(person);
		await context.SaveChangesAsync();

		return Ok(person);
	}

	[HttpDelete("Delete/{id}")]
	public async Task<IActionResult> Delete([FromBody] Guid id, [FromServices] AppDbContext context) {
		var pessoa = await context.Pessoas.FirstOrDefaultAsync(p => p.Id == id);

		if (pessoa == null)
			return BadRequest("Id invalido!!");

		context.Pessoas.Remove(pessoa);
		await context.SaveChangesAsync();
		return Ok("Pessoa Deletada!");
	}

	[HttpDelete("DeleteAll")]
	public async Task<IActionResult> DeleteAll([FromBody] AppDbContext context) {
		context.Pessoas.RemoveRange(context.Pessoas);
		await context.SaveChangesAsync();
		return Ok("Pessoas Deletadas!");
	}
}