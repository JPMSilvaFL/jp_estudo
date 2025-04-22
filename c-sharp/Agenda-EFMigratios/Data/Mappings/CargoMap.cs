using System.Data.Common;
using Agenda_EFMigratios.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Agenda_EFMigratios.Data.Mappings;

public class CargoMap : IEntityTypeConfiguration<Cargo> {
	public void Configure(EntityTypeBuilder<Cargo> builder)
	{
		builder.ToTable("Cargo");

		builder.HasKey(c => c.Id);
		builder.Property(c => c.Id)
			.HasColumnName("Id")
			.HasColumnType("uniqueidentifier")
			.IsRequired();
		builder.HasIndex()
			.IsUnique();
	}
}

// Id Nome Descricao Salario