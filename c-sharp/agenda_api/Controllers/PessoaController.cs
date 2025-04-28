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

	[HttpDelete("Delete/{id:guid}")]
	public async Task<IActionResult> Delete([FromBody] Guid id) {
		var pessoa = await _repository.GetByIdAsync(id);

		if (pessoa == null)
			return BadRequest(new ResultViewModel<Pessoa>("Id invalido!"));

		await _repository.DeleteAsync(id);
		await _repository.SaveChangesAsync();
		return Ok("Pessoa Deletada!");
	}

	[HttpDelete("DeleteAll")]
	public async Task<IActionResult> DeleteAll() {
		_repository.DeleteAll();
		await _repository.SaveChangesAsync();
		return Ok();
	}

	[HttpPost("create")]
	public async Task<IActionResult> CadastraPessoa([FromBody] EditorPessoa pessoa) {
		var pessoaCriada = new Pessoa(pessoa.Cpf, pessoa.FullName, pessoa.Email, pessoa.Contato, pessoa.Endereco);
		await _repository.AddAsync(pessoaCriada);
		await _repository.SaveChangesAsync();
		return Ok(new ResultViewModel<Pessoa>(pessoaCriada));
	}
}