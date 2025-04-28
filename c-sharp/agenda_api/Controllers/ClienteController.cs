using agenda_api.Collections.Repository;
using agenda_api.Data;
using agenda_api.Models;
using agenda_api.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace agenda_api.Controllers;

[ApiController]
[Route("cliente")]
public class ClienteController : ControllerBase {
	private readonly IRepository<Pessoa> _pessoaRepository;
	private readonly IRepository<Cliente> _clienteRepository;

	public ClienteController(IRepository<Pessoa> pessoaRepository, IRepository<Cliente> clienteRepository) {
		_pessoaRepository = pessoaRepository;
		_clienteRepository = clienteRepository;
	}

	[HttpGet("lista")]
	public async Task<IActionResult> ListaClientes([FromServices] AppDbContext context) {
		var clientes = await context
			.Clientes
			.AsNoTracking()
			.Include(p => p.Pessoa)
			.Where(p => p.Pessoa.IsActive == true)
			.ToListAsync();
		return Ok(new ResultViewModel<Cliente>(clientes));
	}

	[HttpPost("createcliente")]
	public async Task<IActionResult> CadastraCliente([FromBody] EditorCliente cliente) {
		var idpessoa = cliente.PessoaId;
		if (idpessoa == Guid.Empty)
			return BadRequest(new ResultViewModel<Cliente>("Erro ao cadastrar cliente!"));

		var criaCliente = new Cliente(await _pessoaRepository.GetByIdAsync(cliente.PessoaId));
		await _clienteRepository.AddAsync(criaCliente);
		await _clienteRepository.SaveChangesAsync();
		return Ok(new ResultViewModel<Cliente>(criaCliente));
	}
}