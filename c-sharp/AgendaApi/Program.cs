using AgendaApi.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

ServicesConfigure(builder);

var app = builder.Build();

app.MapControllers();
app.UseHttpsRedirection();
app.Run();

void ServicesConfigure(WebApplicationBuilder builder) {
	builder.Services.AddDbContext<AgendaDbContext>(options
		=>options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
		);
	builder.Services.AddControllers();
}