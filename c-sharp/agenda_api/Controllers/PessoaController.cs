using agenda_api.Collections.Repository;
using agenda_api.Data;
using agenda_api.Models;
using agenda_api.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace agenda_api.Controllers;

[ApiController]
[Route("pessoa")]
public class PessoaController : ControllerBase {
	private readonly IRepository<Pessoa> _repository;
	public PessoaController(IRepository<Pessoa> repository) {
		_repository = repository;
	}

	[HttpGet("lista")]
	public async Task<IActionResult> GetAll() {
		try {
			var pessoas = await _repository.GetAllAsync();
			if (pessoas.Count == 0)
				return BadRequest(new ResultViewModel<Pessoa>("Nenhuma pessoa encontrada"));

			return Ok(new ResultViewModel<Pessoa>(pessoas));
		}
		catch {
			return StatusCode(500, new ResultViewModel<Pessoa>("Falha interna do servidor"));
		}
	}

	[HttpPost("Create")]
	public async Task<IActionResult> Post([FromBody] EditorPessoa pessoa, [FromServices] AppDbContext context) {
		try {
			if (!ModelState.IsValid) {
				var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage);
				return BadRequest(new ResultViewModel<Pessoa>(errors.ToList()));
			}

			var person = new Pessoa(pessoa.Cpf, pessoa.FullName, pessoa.Email, pessoa.Contato, pessoa.Endereco);

			await context.Pessoas.AddAsync(person);
			await context.SaveChangesAsync();

			return Ok(new ResultViewModel<Pessoa>(person));
		}
		catch {
			return StatusCode(500, new ResultViewModel<Pessoa>("Falha interna do servidor"));
		}
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