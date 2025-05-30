﻿using agenda_api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace agenda_api.Data.Mappings;

public class CargoMap : IEntityTypeConfiguration<Cargo> {
	public void Configure(EntityTypeBuilder<Cargo> builder) {
		builder.ToTable("Cargo");

		builder.HasKey(c => c.Id);
		builder.Property(c => c.Id)
			.HasColumnName("Id")
			.HasColumnType("uniqueidentifier")
			.IsRequired();
		builder.HasIndex(c => c.Id)
			.IsUnique();

		builder.Property(c => c.Nome)
			.HasColumnName("Nome")
			.HasColumnType("nvarchar")
			.HasMaxLength(30)
			.IsRequired();
		builder.HasIndex(c => c.Nome)
			.IsUnique();

		builder.Property(c => c.Descricao)
			.HasColumnName("Descricao")
			.HasColumnType("nvarchar")
			.HasMaxLength(100)
			.IsRequired();

		builder.Property(c => c.Salario)
			.HasColumnName("Salario")
			.HasColumnType("money")
			.IsRequired();
	}
}

// Id Nome Descricao Salario