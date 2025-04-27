using agenda_api.Data;
using agenda_api.Models;
using agenda_api.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace agenda_api.Controllers;

[ApiController]
[Route("usuario")]
public class UsuarioController : ControllerBase {
	[HttpPost("create")]
	public async Task<IActionResult> CriarUsuarioComPessoa([FromBody] EditorUsuario usuario, [FromServices] AppDbContext context) {
		var pessoa = await context.Pessoas.FirstOrDefaultAsync(x => x.Id == usuario.PessoaId);
		if (pessoa == null)
			return NotFound("Insira uma pessoa válida");
		var acesso = await context.PerfilAcessos.FirstOrDefaultAsync(x => x.Id == usuario.IdAcesso);
		if (acesso == null)
			return NotFound("Perfil de acesso invalido");
		var usuarioCriado = new Usuario(acesso, pessoa, usuario.Username, usuario.Password);

		await context.Usuarios.AddAsync(usuarioCriado);
		await context.SaveChangesAsync();

		return Ok(usuarioCriado);
	}
}