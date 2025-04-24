using agenda_api.Models;
using agenda_api.Models.Notifications;
using Agenda_EFMigratios.Data.Mappings;
using Microsoft.EntityFrameworkCore;

namespace agenda_api.Data;

public class AppDbContext : DbContext {
	public DbSet<Pessoa> Pessoas { get; set; }
	public DbSet<Cliente> Clientes { get; set; }
	public DbSet<Funcionario> Funcionarios { get; set; }
	public DbSet<Cargo> Cargos { get; set; }

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
		optionsBuilder.UseSqlite("Data Source=app.db");
	}

	protected override void OnModelCreating(ModelBuilder modelBuilder) {
		modelBuilder.Ignore<Notification>();
		modelBuilder.ApplyConfiguration(new PessoaMap());
		modelBuilder.ApplyConfiguration(new ClienteMap());
		modelBuilder.ApplyConfiguration(new FuncionarioMap());
		modelBuilder.ApplyConfiguration(new CargoMap());
	}
}