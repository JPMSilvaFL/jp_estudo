using agenda_api.Data;
using agenda_api.Models;
using agenda_api.Services;
using agenda_api.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace agenda_api.Controllers;

[Route("login")]
[ApiController]
public class LoginController : ControllerBase {
	private readonly TokenService _tokenService;

	public LoginController(TokenService tokenService) {
		_tokenService = tokenService;
	}

	[HttpPost("geraToken")]
	public IActionResult Login([FromBody] LoginUsuario filter, [FromServices] AppDbContext context) {
		var usuarioValido = context
			.Usuarios
			.FirstOrDefault(x => x.Username == filter.Username && x.Password == filter.Password);
		if (usuarioValido == null)
			return NotFound(new ResultViewModel<Usuario>("usuario invalido"));
		var token = _tokenService.GenerateToken(usuarioValido);
		return Ok(token);
	}
}