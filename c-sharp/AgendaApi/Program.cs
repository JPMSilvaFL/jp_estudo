using System.Text.Json.Serialization;
using AgendaApi.Collections.Repositories;
using AgendaApi.Collections.Repositories.Interfaces;
using AgendaApi.Collections.Repositories.Interfaces.Profiles;
using AgendaApi.Collections.Repositories.Profiles;
using AgendaApi.Collections.Services.Interfaces;
using AgendaApi.Collections.Services.Profiles;
using AgendaApi.Data;
using AgendaApi.Models.Profiles;
using Microsoft.EntityFrameworkCore;

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

	builder.Services.AddDbContext<AgendaDbContext>(options =>
		options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
	builder.Services.AddTransient<UserService>();
	builder.Services.AddTransient<IPersonService, PersonService>();
	builder.Services.AddTransient<ICustomerService, CustomerService>();

	builder.Services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
	builder.Services.AddTransient<IUserRepository, UserRepository>();
	builder.Services.AddTransient<IPersonRepository, PersonRepository>();
	builder.Services.AddTransient<ICustomerRepository, CustomerRepository>();
}