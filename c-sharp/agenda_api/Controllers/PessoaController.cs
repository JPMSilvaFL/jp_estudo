using agenda_api.Data;
using agenda_api.Models;
using Microsoft.AspNetCore.Mvc;

namespace agenda_api.Controllers;

[Route("Pessoa/")]
public class PessoaController : ControllerBase {
	[HttpGet("ListaPessoas")]
	public IActionResult GetAll(AppDbContext context)
	{
		return Ok(context.Pessoas);
	}

	[HttpPost("Create")]
	public IActionResult Post([FromBody] Pessoa pessoa, [FromServices] AppDbContext context)
	{
		var person = new Pessoa(pessoa.Cpf, pessoa.FullName, pessoa.Email, pessoa.Contato, pessoa.Endereco);

		if (person.Notifications.Count > 0)
			return BadRequest(person.Notifications);

		context.Pessoas.Add(person);
		context.SaveChanges();

		return Ok(person);
	}

	[HttpDelete("Delete/{id}")]
	public IActionResult Delete(Guid id, AppDbContext context)
	{
		var pessoa = context.Pessoas.FirstOrDefault(p => p.Id == id);

		if (pessoa == null)
			return BadRequest("Id invalido!!");

		context.Pessoas.Remove(pessoa);
		context.SaveChanges();
		return Ok("Pessoa Deletada!");
	}

	[HttpDelete("DeleteAll")]
	public IActionResult DeleteAll(AppDbContext context)
	{
		context.Pessoas.RemoveRange(context.Pessoas);
		context.SaveChanges();
		return Ok("Pessoas Deletadas!");
	}
}