using Agenda_EFMigratios.Data.Mappings;
using Agenda_EFMigratios.Models;
using Agenda_EFMigratios.Models.Notifications;
using Microsoft.EntityFrameworkCore;

namespace Agenda_EFMigratios.Data;

public class AgendaDataContext : DbContext {
	public DbSet<Pessoa> Pessoas { get; set; }
	public DbSet<Cliente> Clientes { get; set; }
	public DbSet<Cargo> Cargos { get; set; }
	public DbSet<Funcionario> Funcionarios { get; set; }


	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		optionsBuilder.UseSqlServer(
			"Server=localhost,1433;Database=AgendaEF;User Id=sa;Password=152369Jp@;Encrypt=True;TrustServerCertificate=True;");
	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Ignore<Notification>();
		modelBuilder.ApplyConfiguration(new PessoaMap());
		modelBuilder.ApplyConfiguration(new ClienteMap());
		modelBuilder.ApplyConfiguration(new FuncionarioMap());
		modelBuilder.ApplyConfiguration(new CargoMap());
	}
}