using agenda_api.Collections.Repository;
using agenda_api.Collections.Repository.Interfaces;
using agenda_api.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped(typeof(IUsuarioRepository), typeof(UsuarioRepository));
builder
	.Services
	.AddControllers()
	.ConfigureApiBehaviorOptions(options => { options.SuppressModelStateInvalidFilter = true; });

var app = builder.Build();

app.MapControllers();

app.Run();