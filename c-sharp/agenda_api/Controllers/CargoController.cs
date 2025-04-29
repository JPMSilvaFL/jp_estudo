using agenda_api.Collections.Repository;
using agenda_api.Collections.Repository.Interfaces;
using agenda_api.Data;
using agenda_api.Models;
using agenda_api.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace agenda_api.Controllers;

[ApiController]
[Route("cargo")]
public class CargoController : ControllerBase {
	private readonly IRepository<Cargo> _repository;

	public CargoController(IRepository<Cargo> repository) {
		_repository = repository;
	}


	[HttpPost("create")]
	public async Task<IActionResult> Create([FromBody] EditorCargo cargo) {
		var cargoCriado = new Cargo(cargo.Nome, cargo.Descricao, cargo.Salario);

		await _repository.AddAsync(cargoCriado);
		await _repository.SaveChangesAsync();
		return Ok(new ResultViewModel<Cargo>(cargoCriado));
	}

	[HttpGet("lista")]
	public async Task<IActionResult> Lista() {
		var cargos = await _repository.GetAllAsync();
		return Ok(new ResultViewModel<IList<Cargo>>(cargos));
	}
}