using agenda_api.Data.Mappings;
using agenda_api.Models;
using Microsoft.EntityFrameworkCore;

namespace agenda_api.Data;

public class AppDbContext : DbContext {
	public DbSet<Pessoa> Pessoas { get; set; }
	public DbSet<Cliente> Clientes { get; set; }
	public DbSet<Funcionario> Funcionarios { get; set; }
	public DbSet<Cargo> Cargos { get; set; }
	public DbSet<PerfilAcesso> PerfilAcessos { get; set; }
	public DbSet<Usuario> Usuarios { get; set; }
	public DbSet<LogAtividade> LogAtividades { get; set; }

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
		optionsBuilder.UseSqlite("Data Source=app.db");
	}

	protected override void OnModelCreating(ModelBuilder modelBuilder) {
		modelBuilder.ApplyConfiguration(new PessoaMap());
		modelBuilder.ApplyConfiguration(new ClienteMap());
		modelBuilder.ApplyConfiguration(new FuncionarioMap());
		modelBuilder.ApplyConfiguration(new CargoMap());
		modelBuilder.ApplyConfiguration(new PerfilAcessoMap());
		modelBuilder.ApplyConfiguration(new UsuarioMap());
		modelBuilder.ApplyConfiguration(new LogAtividadeMap());
		modelBuilder.ApplyConfiguration(new SecretariaMap());
		modelBuilder.ApplyConfiguration(new HorarioDisponivelMap());
		modelBuilder.ApplyConfiguration(new AtendimentoMap());
	}
}