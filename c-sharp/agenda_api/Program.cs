using System.Text;
using agenda_api;
using agenda_api.Collections.Repository;
using agenda_api.Collections.Repository.Interfaces;
using agenda_api.Data;
using agenda_api.Models;
using agenda_api.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>();
builder.Services.AddScoped<TokenService>();

var key = Encoding.ASCII.GetBytes(Configuration.JwtKey);
builder.Services.AddAuthentication(x => {
	x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
	x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x => {
	x.TokenValidationParameters = new TokenValidationParameters {
		ValidateIssuerSigningKey = true,
		IssuerSigningKey = new SymmetricSecurityKey(key),
		ValidateIssuer = false,
		ValidateAudience = false
	};
});

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped(typeof(Repository<Usuario>), typeof(UsuarioRepository));
builder
	.Services
	.AddControllers()
	.ConfigureApiBehaviorOptions(options => { options.SuppressModelStateInvalidFilter = true; });

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();