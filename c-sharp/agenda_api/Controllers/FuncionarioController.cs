using agenda_api.Collections.Repository;
using agenda_api.Models;
using agenda_api.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace agenda_api.Controllers;

[ApiController]
[Route("funcionario")]
public class FuncionarioController : ControllerBase {
	private readonly IRepository<Pessoa> _pessoaRepository;
	private readonly IRepository<Cargo> _cargoRepository;
	private readonly IRepository<Funcionario> _funcionarioRepository;

	public FuncionarioController(IRepository<Pessoa> pessoaRepository, IRepository<Cargo> cargoRepository,
		IRepository<Funcionario> funcionarioRepository) {
		_pessoaRepository = pessoaRepository;
		_cargoRepository = cargoRepository;
		_funcionarioRepository = funcionarioRepository;
	}


	[HttpPost("create")]
	public async Task<IActionResult> Post([FromBody] EditorFuncionario create) {
		var pessoa = await _pessoaRepository.GetByIdAsync(create.IdPessoa);

		var cargo = await _cargoRepository.GetByIdAsync(create.IdCargo);

		var funcionarioCriado = new Funcionario(cargo, pessoa);
		await _funcionarioRepository.AddAsync(funcionarioCriado);
		await _funcionarioRepository.SaveChangesAsync();
		return Ok(new ResultViewModel<Funcionario>(funcionarioCriado));
	}
}