using Microsoft.EntityFrameworkCore;

namespace agenda_api.Data;

public class AppDbContext : DbContext {
	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		optionsBuilder.UseSqlite("Data Source=app.db");
	}

	protected override void OnModelCreating(ModelBuilder modelBuilder) { }
}