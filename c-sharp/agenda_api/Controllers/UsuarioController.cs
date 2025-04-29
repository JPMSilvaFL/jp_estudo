using agenda_api.Collections.Repository;
using agenda_api.Collections.Repository.Interfaces;
using agenda_api.Data;
using agenda_api.Models;
using agenda_api.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace agenda_api.Controllers;

[ApiController]
[Route("usuario")]
public class UsuarioController : ControllerBase {
	private readonly IRepository<Pessoa> _pessoaRepository;
	private readonly IRepository<PerfilAcesso> _perfilAcessoRepository;
	private readonly IRepository<Funcionario> _funcionarioRepository;

	public UsuarioController(IRepository<Pessoa> pessoaRepository, IRepository<PerfilAcesso> perfilacessoRepository,
		IRepository<Funcionario> funcionarioRepository) {
		_pessoaRepository = pessoaRepository;
		_perfilAcessoRepository = perfilacessoRepository;
		_funcionarioRepository = funcionarioRepository;
	}

	[HttpPost("create")]
	public async Task<IActionResult> CriarUsuarioComPessoa([FromBody] EditorUsuario usuario, [FromServices] AppDbContext context) {
		var pessoa = await context.Pessoas.FirstOrDefaultAsync(x => x.Id == usuario.PessoaId);
		if (pessoa == null)
			return NotFound(new ResultViewModel<Usuario>("Erro ao carregar pessoa no usuario."));
		var acesso = await context.PerfilAcessos.FirstOrDefaultAsync(x => x.Id == usuario.IdAcesso);
		if (acesso == null)
			return NotFound("Perfil de acesso invalido");
		var usuarioCriado = new Usuario(acesso, pessoa, usuario.Username, usuario.Password);

		await context.Usuarios.AddAsync(usuarioCriado);
		await context.SaveChangesAsync();

		return Ok(usuarioCriado);
	}
}