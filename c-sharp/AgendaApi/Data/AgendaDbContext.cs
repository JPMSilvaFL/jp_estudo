using AgendaApi.Data.Mappings;
using AgendaApi.Models.Profiles;
using Microsoft.EntityFrameworkCore;

namespace AgendaApi.Data;

public class AgendaDbContext : DbContext{
	public AgendaDbContext(DbContextOptions<AgendaDbContext> options)
		: base(options)
	{ }
	public DbSet<Person> Persons { get; set; }

	protected override void OnModelCreating(ModelBuilder modelBuilder) {
		modelBuilder.ApplyConfiguration(new PersonMap());
	}
}