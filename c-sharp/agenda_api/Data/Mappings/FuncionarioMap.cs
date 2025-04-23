using agenda_api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Agenda_EFMigratios.Data.Mappings;

public class FuncionarioMap : IEntityTypeConfiguration<Funcionario> {
	public void Configure(EntityTypeBuilder<Funcionario> builder)
	{
		builder.ToTable("Funcionario");

		builder.HasKey(f => f.Id);
		builder.Property(f => f.Id)
			.HasColumnName("Id")
			.HasColumnType("uniqueidentifier")
			.IsRequired();
		builder.HasIndex(f => f.Id)
			.IsUnique();


		builder.Property(f => f.PessoaId)
			.HasColumnName("PessoaId")
			.HasColumnType("uniqueidentifier")
			.IsRequired();

		builder.Property(f => f.CargoId)
			.HasColumnName("CargoId")
			.HasColumnType("uniqueidentifier")
			.IsRequired();

		builder.Property(f => f.DataDeIngresso)
			.HasColumnName("DataDeIngresso")
			.HasColumnType("datetime")
			.IsRequired();

		builder.HasOne(f => f.Cargo)
			.WithMany()
			.HasForeignKey(f => f.CargoId)
			.OnDelete(DeleteBehavior.NoAction);

		builder.HasOne(f => f.Pessoa)
			.WithMany()
			.HasForeignKey(f => f.PessoaId)
			.OnDelete(DeleteBehavior.Cascade);
	}
}