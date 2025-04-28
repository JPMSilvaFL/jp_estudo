using agenda_api.Collections.Repository;
using agenda_api.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder
	.Services
	.AddControllers()
	.ConfigureApiBehaviorOptions(options => {
		options.SuppressModelStateInvalidFilter = true;
	});

var app = builder.Build();

app.MapControllers();

app.Run();