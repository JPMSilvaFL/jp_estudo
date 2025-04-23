using agenda_api.Models;
using agenda_api.Models.Notifications;
using Agenda_EFMigratios.Data.Mappings;
using Microsoft.EntityFrameworkCore;

namespace agenda_api.Data;

public class AppDbContext : DbContext {
	public DbSet<Pessoa> Pessoas { get; set; }

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		optionsBuilder.UseSqlite("Data Source=app.db");
	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Ignore<Notification>();
		modelBuilder.ApplyConfiguration(new PessoaMap());
	}
}