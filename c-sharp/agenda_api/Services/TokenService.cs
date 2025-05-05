using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using agenda_api.Data;
using agenda_api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace agenda_api.Services;

public class TokenService {
	private readonly AppDbContext _context;

	public TokenService(AppDbContext context) {
		_context = context;
	}

	public string GenerateToken(Usuario usuario) {
		var usuarioDb = _context
			.Usuarios
			.AsNoTracking()
			.Include(x => x.Acesso)
			.FirstOrDefault();

		var tokenHandler = new JwtSecurityTokenHandler();
		var key = Encoding.ASCII.GetBytes(Configuration.JwtKey);
		var tokenDescriptor = new SecurityTokenDescriptor {
			Subject = new ClaimsIdentity([
				new Claim(ClaimTypes.Name, usuario.Username),
				new Claim("PessoaId", usuario.PessoaId.ToString()),
				new Claim("PerfilAcessoId", usuario.PerfilAcessoId.ToString()),
				new Claim(ClaimTypes.Role, usuarioDb.Acesso.Nome)
			]),
			Expires = DateTime.UtcNow.AddHours(6),
			SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
		};
		var token = tokenHandler.CreateToken(tokenDescriptor);
		return tokenHandler.WriteToken(token);
	}
}