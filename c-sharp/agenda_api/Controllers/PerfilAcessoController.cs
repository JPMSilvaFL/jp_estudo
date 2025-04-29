using agenda_api.Collections.Repository;
using agenda_api.Data;
using agenda_api.Models;
using agenda_api.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace agenda_api.Controllers;

[ApiController]
[Route("acesso")]
public class PerfilAcessoController : ControllerBase {
	private readonly IRepository<PerfilAcesso> _repository;

	public PerfilAcessoController(IRepository<PerfilAcesso> repository) {
		_repository = repository;
	}

	[HttpPost("create")]
	public async Task<IActionResult> Criar([FromBody] EditorAcesso acesso) {
		var acessoCriado = new PerfilAcesso(acesso.Nome);
		await _repository.AddAsync(acessoCriado);
		await _repository.SaveChangesAsync();
		return Ok(new ResultViewModel<PerfilAcesso>(acessoCriado));
	}

	[HttpGet("lista")]
	public async Task<IActionResult> Lista() {
		var listaAcessos = await _repository.GetAllAsync();

		return Ok(new ResultViewModel<PerfilAcesso>(listaAcessos));
	}
}