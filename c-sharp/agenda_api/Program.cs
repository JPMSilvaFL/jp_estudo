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
ConfigureAuthentication(builder);
ConfigureMvc(builder);
ConfigureServices(builder);

var app = builder.Build();
LoadConfiguration(app);
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();

void LoadConfiguration(WebApplication app) {
	Configuration.JwtKey = app.Configuration.GetValue<string>("JwtKey")!;
	Configuration.ApiKeyName = app.Configuration.GetValue<string>("ApiKeyName")!;
	Configuration.ApiKey = app.Configuration.GetValue<string>("ApiKey")!;

	var smtp = new Configuration.SmtpConfiguration();
	app.Configuration.GetSection("Smtp").Bind(smtp);
	Configuration.Smpt = smtp;
}

void ConfigureAuthentication(WebApplicationBuilder builder) {
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
}

void ConfigureMvc(WebApplicationBuilder builder) {
	builder
		.Services
		.AddControllers()
		.ConfigureApiBehaviorOptions(options => { options.SuppressModelStateInvalidFilter = true; });
}

void ConfigureServices(WebApplicationBuilder builder) {
	builder.Services.AddDbContext<AppDbContext>();
	builder.Services.AddScoped<TokenService>();
	builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
	builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
}