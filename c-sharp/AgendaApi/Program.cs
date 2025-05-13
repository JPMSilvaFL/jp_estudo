using System.Text.Json.Serialization;
using AgendaApi.Collections.Repositories;
using AgendaApi.Collections.Repositories.Interfaces;
using AgendaApi.Collections.Services.Profiles;
using AgendaApi.Data;

var builder = WebApplication.CreateBuilder(args);

ConfigureMvc(builder);
ConfigureServices(builder);

var app = builder.Build();

app.MapControllers();
app.UseHttpsRedirection();
app.Run();

void ConfigureMvc(WebApplicationBuilder builder) {
	builder
		.Services
		.AddControllers()
		.ConfigureApiBehaviorOptions(options => { options.SuppressModelStateInvalidFilter = true; })
		.AddJsonOptions(x => {
			x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
			x.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault;
		});
}

void ConfigureServices(WebApplicationBuilder builder) {
	builder.Services.AddDbContext<AgendaDbContext>();
	builder.Services.AddScoped<UserService>();

	builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
	builder.Services.AddScoped<IUserRepository, UserRepository>();
	builder.Services.AddScoped<IPersonRepository, PersonRepository>();
}